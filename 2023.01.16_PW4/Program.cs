using System.Text;

WebApplication app = WebApplication.CreateBuilder().Build();
app.MapGet("/", () => $"Hello from {app.Environment.ApplicationName}!");
app.MapGet("/home", () => "Select your choice!");
app.MapGet("/home/task1", () => "Batsemakin Pavel");
app.MapGet("/home/task2", () => $"Hello from {app.Environment.ApplicationName}! Today is {DateTime.Now.ToShortDateString()}.");
app.MapGet("/home/task3", c =>
{
    StringBuilder builder = new();
    builder.AppendLine("<div>");
    builder.AppendLine("<ol>");
    builder.AppendLine("<li>Complete the practical and the home work from the first lesson of ASP.NET Core</li>");
    builder.AppendLine("<li>Edit my readme on GitHub</li>");
    builder.AppendLine("<li>Start second lesson of ASP</li>");
    builder.AppendLine("</ol>");
    builder.AppendLine("</div>");
    return c.Response.WriteAsync(builder.ToString());
});
app.Run();
