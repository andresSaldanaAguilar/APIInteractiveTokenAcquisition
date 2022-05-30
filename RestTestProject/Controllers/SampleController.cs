using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace RestTestProject.Controllers
{
    /// <summary>
    /// Sample controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        public SampleController() {}

        /// <summary>
        /// Sample endpoint
        /// </summary>
        /// <returns>Messsage</returns>
        [HttpGet(Name = "Sample")]
        public string GetSample()
        {
            return "You're authorized to see this.";
        }
    }
}