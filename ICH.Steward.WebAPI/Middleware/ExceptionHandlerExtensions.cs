using System;
using ICH.Steward.WebAPI.Middleware;
using ICH.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ICH.WebAPI.Middleware
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseCustomerExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(errorApp =>
             {
                // Normally you'd use MVC or similar to render a nice page.
                errorApp.Run(async context =>
                 {
                     context.Response.StatusCode = 501;
                     context.Response.ContentType = "application/json";

                     var error = context.Features.Get<IExceptionHandlerFeature>();
                     
                     if (error != null)
                     {
                         //if (error.Error is NotImplementedException)
                         //{//TODO:自定义返回异常信息
                         //    string log = JsonConvert.SerializeObject(ResponseResult.Execute(error.Error)); //真实日志信息
                         //    string text=JsonConvert.SerializeObject(ResponseResult.Execute("自定义返回内容"));
                         //    await context.Response.WriteAsync(text);
                         //}
                         if (error.Error is TimeoutException)
                         {//TODO:自定义返回异常信息

                             string text = JsonConvert.SerializeObject(ResponseResult.Execute("10010", "任务超时"));
                             await context.Response.WriteAsync(text);
                         }
                         else if (error.Error is StewardException)
                         {
                            var ex= error.Error as StewardException;
                             string text = JsonConvert.SerializeObject(ResponseResult.Execute(ex.Code,ex.Message));
                             await context.Response.WriteAsync(text);
                         }
                         else
                         {
                             string text = JsonConvert.SerializeObject(ResponseResult.Execute("10001", "系统错误"));
                             await context.Response.WriteAsync(text);
                         }
                         //TODO:异步记录日志
                     }
                 });
             });
        }
    }
}
