using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ICH.Steward.WebAPI.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Method.Equals("OPTIONS"))
            {
                try
                {
                    if (context.Request.Headers.GetCommaSeparatedValues("Authorization").Any())
                    {
                        var accessToken = context.Request.Headers.GetCommaSeparatedValues("Authorization")[0];
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            var claims = new List<Claim> { new Claim(ClaimTypes.Authentication, accessToken) };
                            var identity = new ClaimsIdentity(claims);
                            var principal = new ClaimsPrincipal(identity);
                            context.User = principal;
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }
            await _next.Invoke(context); //正常返回信息；
        }
    }
}
