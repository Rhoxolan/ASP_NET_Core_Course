namespace _2023._01._23_PW.Middelwares
{
    public class ColorResponseMiddelware
    {
        private readonly RequestDelegate _next;

        public ColorResponseMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration appConfig)
        {
            context.Response.Headers.Add("Content-Type", "text/html;charset=utf-8");
            string color = "";
            if(!String.IsNullOrEmpty(appConfig["color"]))
            {
                color = appConfig["color"]!;
            }
            else
            {
                color = "dark";
            }
            await context.Response.WriteAsync($"<div style='color:{color};margin:5px'>");
            await _next(context);
            await context.Response.WriteAsync($"</div>");
        }
    }
}
