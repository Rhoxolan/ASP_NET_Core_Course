using _2023._01._25_PW;
using static System.String;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(options
    => options.ConstraintMap.Add("endssetup", typeof(EndsSetupConstraint)));

var app = builder.Build();

app.Map("/", () => "Hello!");

//Task 1
app.Map("/newOrder", async context
    => await context.Response.WriteAsync(Join(" ", context.Request.Host.Host, context.Request.Protocol)));

//Task 2
app.Map("/Home/{name:maxlength(6)}/{value:maxlength(6)}", (string name, string value)
    => $"You requested {name} - {value}");

//Task 3
app.Map("usersettings/{id:range(1,999)}", (HttpContext context, uint id)
    => context.Response.Redirect($"/user/settings/{id}"));
app.Map("user/settings/{id:range(1,999)}", (uint id)
    => $"Id of your user is {id}");

//Task 4
app.Map("/Admin/{value:endssetup}", (string value)
    => $"Request on {value} is received");

//Task 5
app.Map("/shop/archive/{date:datetime}", (DateTime date)
    => $"You requested shop archive on {date.ToShortDateString()}");

app.Run();
