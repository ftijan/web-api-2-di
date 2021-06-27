using Owin;

namespace Example.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Configure(app);
        }
    }
}