using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICH.Steward.Domain;
using ICH.Steward.Domain.Models;
using ICH.Util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ICH.Steward.WebAPI.Controllers
{
    [Route("api/authorization_code")]
    [EnableCors("CorsPolicy")]
    public class AuthorizationCodeController : Controller
    {
        private IMemoryCache _memoryCache;
        public AuthorizationCodeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody]AuthorizationCodeModel data)
        {
            var parameters =
                $"grant_type=authorization_code&code={data.code}&state={data.state}&redirect_uri={data.redirect_uri}&client_id={AppSettings.ClientId}&client_secret={AppSettings.ClientSecret}";
            var result = await WebUtils.DoPostAsync(AppSettings.TokenEndpoint, parameters, "utf-8"); //得到令牌

            var resdata = JsonConvert.DeserializeObject<dynamic>(result);
            if (resdata.access_token == null)
            {
                return Json(ResponseResult.Execute("10027", "授权码已不存在或已过期"));
            }
            string access_token = resdata.access_token;
            int expires_in = resdata.expires_in;
            string token_type = resdata.token_type;
            string refresh_token = resdata.refresh_token;

            if (string.IsNullOrEmpty(access_token))
            {
                return Json(ResponseResult.Execute("10009", "任务过多，系统繁忙"));
            }
            _memoryCache.Set(access_token, DateTime.Now.AddSeconds(expires_in), TimeSpan.FromSeconds(expires_in));    //令牌写入缓存

            return Json(ResponseResult.Execute(new {access_token , token_type, expires_in, refresh_token }));
        }
    }
}