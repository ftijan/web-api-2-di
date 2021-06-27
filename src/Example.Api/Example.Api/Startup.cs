using Owin;

namespace Example.Api
{
    /// <summary>
    /// The OWIN startup entry point.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the API.
        /// </summary>
        /// <param name="app">The app builder instance.</param>
        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Configure(app);
        }
    }
}