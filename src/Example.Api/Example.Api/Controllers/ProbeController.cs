using System.Web.Http;

namespace Example.Api.Controllers
{    
    public class ProbeController : ApiController
    {
        public IHttpActionResult Get()
        {           
            return Ok();
        }
    }
}