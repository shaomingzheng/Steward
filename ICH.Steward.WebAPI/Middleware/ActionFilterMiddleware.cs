using System;
using ICH.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ICH.WebAPI.Middleware
{
    public class ActionFilterMiddleware : ActionFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //根据实际需求进行具体实现
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                context.Result = objectResult.Value == null ? new JsonResult(ResponseResult.Execute("404", "Not Found")) : new JsonResult(ResponseResult.Execute(objectResult.Value));
            }
            else if (context.Result is EmptyResult)
            {
                context.Result = new JsonResult(ResponseResult.Execute("404", "Not Found"));
            }
            else if (context.Result is ContentResult)
            {
                context.Result = new JsonResult(ResponseResult.Execute((context.Result as ContentResult).Content));
            }
            else if (context.Result is StatusCodeResult)
            {
                context.Result = new JsonResult(ResponseResult.Execute((context.Result as StatusCodeResult).StatusCode.ToString(), ""));
            }
            base.OnResultExecuting(context);
        }
    }
}

