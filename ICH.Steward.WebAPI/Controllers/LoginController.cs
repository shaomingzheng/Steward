using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ICH.Core.Net;
using ICH.Core.Web;
using ICH.Steward.Domain;
using ICH.Steward.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using ICH.Steward.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Cors;

namespace ICH.Steward.WebAPI.Controllers
{
    [Route("api/login")]
    [EnableCors("CorsPolicy")]
    public class LoginController : Controller
    {
        private IMemoryCache _memoryCache;
        private IBaseUserRepository _baseUserRepository;
        public LoginController( IMemoryCache memoryCache, IBaseUserRepository baseUserRepository)
        {
            _memoryCache = memoryCache;
            _baseUserRepository = baseUserRepository;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post()
        {
            if (!HttpContext.User.HasClaim(c => c.Type == ClaimTypes.Authentication))
            {
                return Json(ResponseResult.Execute("10008", "参数错误，请参考API文档"));
            }

            var clamin = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Authentication);
            if (!string.IsNullOrEmpty(clamin.Value))
            {
                DateTime expireTime;
                if (_memoryCache.TryGetValue(clamin.Value, out expireTime))
                {
                    var parameters = $"access_token={clamin.Value}";
                    var result = await WebUtils.DoPostAsync(AppSettings.UserInfoEndpoint, parameters, "utf-8");    //得到用户信息
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                    var userdata = data.data;
                    if (data.code == "0"&&null!= userdata)
                    {
                        //判断是否是内部员工
                        string openid = userdata.openid;
                        bool isExist = await _baseUserRepository.ExistAsync(c => c.OpenId == openid && c.EnabledMark == 1 && c.DeleteMark == 0);

                        if (isExist)
                        {
                            var user = new UserInfoModel
                            {
                                cellphone = userdata.cellphone,
                                email = userdata.email,
                                figureurl = userdata.figureurl,
                                nickname = userdata.nickname,
                                openid = userdata.openid,
                                sex = userdata.sex
                            };
                            _memoryCache.Set(clamin.Value,user, expireTime - DateTime.Now);
                            return Json(ResponseResult.Execute(user));
                        }
                        return Json(ResponseResult.Execute("20001", "用户不存在"));
                    }
                    return Json(ResponseResult.Execute("10009", "任务过多，系统繁忙"));
                }
            }
            return Json(ResponseResult.Execute("10026", "令牌不存在或已过期"));
        }
    }
}