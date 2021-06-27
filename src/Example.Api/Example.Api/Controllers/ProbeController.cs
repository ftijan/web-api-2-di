using NLog;
using System.Web.Http;

namespace Example.Api.Controllers
{
    /// <summary>
    /// The probe controller.
    /// </summary>
    public class ProbeController : ApiController
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Creates an instance of <see cref="ProbeController"/>.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public ProbeController(ILogger logger)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }        

        /// <summary>
        /// Logs the request and returns a 200 OK.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            logger.Debug("GET /probe");

            return Ok();
        }
    }
}