using _2023._01._20_PW.ResponseNumber;

namespace _2023._01._20_PW.Extensions
{
    public static class ResponseNumberServiceExtension
    {
        public static void AddResponseNumberService(this IServiceCollection services)
        {
            services.AddTransient<IResponseNumber, FibonacciResponse>();
        }
    }
}
