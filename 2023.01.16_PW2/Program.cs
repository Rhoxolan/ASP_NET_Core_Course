namespace _2023._01._16_PW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => $"Hello from {app.Environment.ApplicationName}! Today is {DateTime.Now.ToShortDateString()}.");

            app.Run();
        }
    }
}