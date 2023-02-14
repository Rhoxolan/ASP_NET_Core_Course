using _2023._01._20_PW2.Middelwares;

namespace _2023._01._20_PW2.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDrinkMiddelware(this IApplicationBuilder appbuilder)
            => appbuilder.UseMiddleware<ErrorHandlingMiddleware>()
            .UseMiddleware<QueryCheckerMiddleware>()
            .UseMiddleware<QueryDrinkCheckerMiddleware>()
            .UseMiddleware<DrinkMiddelware>();
    }
}
