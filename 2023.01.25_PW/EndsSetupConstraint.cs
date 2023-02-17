namespace _2023._01._25_PW
{
    public class EndsSetupConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            => Equals(values[routeKey]?.ToString()?.EndsWith("setup"), true);
    }
}