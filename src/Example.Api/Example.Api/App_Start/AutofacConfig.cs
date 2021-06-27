using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace Example.Api
{
    /// <summary>
    /// Configures the  Autofac DI setup logic.
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// The container instance.
        /// </summary>
        public static IContainer Container;

        /// <summary>
        /// Calls the DI initialization logic.
        /// </summary>
        /// <param name="configuration">The <see cref="HttpConfiguration"/> instance.</param>
        public static void Initialize(HttpConfiguration configuration)
        {
            Initialize(configuration, RegisterServices(new ContainerBuilder()));
        }

        /// <summary>
        /// Calls the DI initialization logic.
        /// </summary>
        /// <param name="configuration">The <see cref="HttpConfiguration"/> instance.</param>
        /// <param name="container">The <see cref="IContainer"/> instance.</param>
        public static void Initialize(HttpConfiguration configuration, IContainer container)
        {
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Registers services through Autofac DI logic.
        /// </summary>
        /// <param name="builder">The <see cref="ContainerBuilder"/> instance.</param>
        /// <returns>The <see cref="IContainer"/> instance.</returns>
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            // Register Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register NLog
            builder.RegisterModule<NLogModule>();

            // TODO: add other services

                        
            Container = builder.Build();

            return Container;
        }
    }
}