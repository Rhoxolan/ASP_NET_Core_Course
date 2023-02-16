using _2023._01._23_PW;
using _2023._01._23_PW.Middelwares;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("student.json")
    .AddXmlFile("student.xml");
builder.Services.Configure<Student>(builder.Configuration.GetSection("Student"));




var app = builder.Build();

app.Map("/", () => "Hello!");

app.Map("/home", appbuilder => appbuilder.UseMiddleware<HomeRequestMiddelware>());

app.Map("/academy", appbuilder => appbuilder.UseMiddleware<AcademyRequestMiddelware>());

app.Run();
