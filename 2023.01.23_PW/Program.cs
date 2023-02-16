using _2023._01._23_PW;
using _2023._01._23_PW.Extensions;

string[] commandLineArgs = { "color=red" }; //Command line args simulation
var builder = WebApplication.CreateBuilder(commandLineArgs);
builder.Configuration.AddJsonFile("student.json")
    .AddXmlFile("student.xml");
builder.Services.Configure<Student>(builder.Configuration.GetSection("Student"));

var app = builder.Build();
app.Map("/", () => "Hello!");
app.Map("/home", appbuilder => appbuilder.UseHomeRequestMiddelware());
app.Map("/academy", appbuilder => appbuilder.UseAcademyRequestMiddelware());

app.Run();