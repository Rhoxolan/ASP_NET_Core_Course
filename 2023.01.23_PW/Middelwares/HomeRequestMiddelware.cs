using Microsoft.Extensions.Options;

namespace _2023._01._23_PW.Middelwares
{
    public class HomeRequestMiddelware
    {
        public HomeRequestMiddelware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context, IOptions<Student> options)
        {
            Student student = options.Value;
            await context.Response.WriteAsync($"Student {student.Name} {student.Surname} {student.Age} years old");
        }
    }
}
