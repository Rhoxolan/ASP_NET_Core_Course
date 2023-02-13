using _2023._01._20_PW.Middelwares;

namespace _2023._01._20_PW.Extensions
{
    public static class ResponseNumberMiddelwareExtension
    {
        public static IApplicationBuilder UseResponseNumberMiddelware(this IApplicationBuilder appbuilder)
            => appbuilder.UseMiddleware<ErrorHandlingMiddleware>()
                .UseMiddleware<QueryCheckerMiddleware>()
                .UseMiddleware<QueryNumberCheckerMiddleware>()
                .UseMiddleware<ResponseNumberMiddleware>();
    }
}
