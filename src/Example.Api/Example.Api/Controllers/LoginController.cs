using Example.Api.Auth;
using NLog;
using System.Web.Http;

namespace Example.Api.Controllers
{
    /// <summary>
    /// The login controller.
    /// </summary>
    public class LoginController : ApiController
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Creates an instance of <see cref="LoginController"/>.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public LoginController(ILogger logger)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Triggers the authentication challenge logic.
        /// </summary>        
        [HttpGet]
        public IHttpActionResult Challenge()
        {            
            logger.Debug("GET /login/challenge");

            return new ChallengeResult("Google", "api/home", this.Request);
        }
    }
}