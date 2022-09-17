using System.Web.Http;

namespace ASP.NETCoreWebApplication1.Controllers;

public static class HelloWebAPIConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Web API routes
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            "DefaultApi",
            "api/{controller}/{id}",
            new { id = RouteParameter.Optional }
        );
    }
}