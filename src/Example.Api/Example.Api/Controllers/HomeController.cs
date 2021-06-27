using NLog;
using System.Net.Http;
using System.Web.Http;

namespace Example.Api.Controllers
{
    /// <summary>
    /// The home controller.
    /// </summary>
    [Authorize]
    public class HomeController : ApiController
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Creates an instance of <see cref="HomeController"/>.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public HomeController(ILogger logger)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }        

        /// <summary>
        /// Greets the user if the auth challenge was successful.
        /// </summary>        
        public IHttpActionResult Get()
        {
            logger.Debug("GET /home");
            
            var user = Request.GetOwinContext().Authentication.User;

            return Ok($"Hello from home - welcome, {user.Identity.Name}");
        }
    }
}