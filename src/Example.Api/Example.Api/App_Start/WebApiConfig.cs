using Owin;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Example.Api
{
    public class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            // JSON formatter
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            app.UseWebApi(config);
        }
    }
}