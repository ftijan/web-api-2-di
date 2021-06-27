using Owin;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Example.Api
{
    /// <summary>
    /// Configures the API composition.
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Called by the OWIN <see cref="Startup"/> instance to execute 
        /// application composition and configuration logic.
        /// </summary>
        /// <param name="app">The app builder instance.</param>
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

            // Set Autofac as dependency injector
            AutofacConfig.Initialize(config);

            app.UseWebApi(config);            
        }
    }
}