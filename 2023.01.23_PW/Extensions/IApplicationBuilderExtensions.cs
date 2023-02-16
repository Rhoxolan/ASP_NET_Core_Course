using _2023._01._23_PW.Middelwares;

namespace _2023._01._23_PW.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAcademyRequestMiddelware(this IApplicationBuilder appbuilder)
            => appbuilder.UseMiddleware<ColorResponseMiddelware>()
            .UseMiddleware<AcademyRequestMiddelware>();

        public static IApplicationBuilder UseHomeRequestMiddelware(this IApplicationBuilder appbuilder)
            => appbuilder.UseMiddleware<ColorResponseMiddelware>()
            .UseMiddleware<HomeRequestMiddelware>();
    }
}
