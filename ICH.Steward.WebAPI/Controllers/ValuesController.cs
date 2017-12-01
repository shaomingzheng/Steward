using System.Collections.Generic;
using System.Threading.Tasks;
using ICH.Core.Cache;
using ICH.Core.Web;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Steward.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ICH.Steward.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    //[Authorize(Policy = "Token")]
    public class ValuesController : Controller
    {
        private IUserRepository _userRepository;
        private ICacheService _cache;
        public ValuesController(IUserRepository userRepository, ICacheService cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            //var a=_cache.Get<Base_UserEntity>("test");
            bool r = await _cache.AddAsync("test", "ichnb");
            return Json(ResponseResult.Execute(r));
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
