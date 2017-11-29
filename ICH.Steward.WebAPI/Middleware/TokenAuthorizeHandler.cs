using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICH.Steward.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace ICH.Steward.WebAPI.Middleware
{
    public class TokenAuthorizeRequirement : IAuthorizationRequirement
    {
    }
    public class TokenAuthorizeHandler : AuthorizationHandler<TokenAuthorizeRequirement>
    {
        private IMemoryCache _memoryCache;
        public TokenAuthorizeHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenAuthorizeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Authentication))
            {
                throw new StewardException {Code = "10026 ",Message = "令牌不存在或已过期" };
                //return Task.CompletedTask;
            }

            var clamin = context.User.FindFirst(c => c.Type == ClaimTypes.Authentication);
            if (!string.IsNullOrEmpty(clamin.Value))
            {
                UserInfoModel user;
                //缓存中验证令牌
                _memoryCache.TryGetValue(clamin.Value, out user);
                if (null != user)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            throw new StewardException { Code = "10026 ", Message = "令牌不存在或已过期" };
        }


    }
}
