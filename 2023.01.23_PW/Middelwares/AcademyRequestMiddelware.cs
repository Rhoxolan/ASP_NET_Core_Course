using Microsoft.Extensions.Options;

namespace _2023._01._23_PW.Middelwares
{
    public class AcademyRequestMiddelware
    {
        public AcademyRequestMiddelware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context, IOptions<Student> options)
        {
            Student student = options.Value;
            await context.Response.WriteAsync($"Student {student.Name} {student.Surname} has skills: {string.Join(", ", student.Skills)}.");
        }
    }
}
