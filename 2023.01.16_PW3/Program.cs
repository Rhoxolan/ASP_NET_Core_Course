using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", c =>
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