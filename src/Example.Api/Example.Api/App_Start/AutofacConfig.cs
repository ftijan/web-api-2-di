using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace Example.Api
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration configuration)
        {
            Initialize(configuration, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration configuration, IContainer container)
        {
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            // Register Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // TODO: add other services
            

            // Set Autofac dependency resolver
            Container = builder.Build();

            return Container;
        }
    }
}