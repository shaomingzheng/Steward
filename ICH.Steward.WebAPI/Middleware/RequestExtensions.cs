using Microsoft.AspNetCore.Builder;

namespace ICH.Steward.WebAPI.Middleware
{
    public static class RequestExtensions
    {
        public static IApplicationBuilder UseRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }
}
