using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Realtor.API.Controllers
{
    [Route("[controller]")]
    public class PropertiesController : ApiController
    {
        [HttpGet]
        public IActionResult ListProperties()
        {
            HttpContext context = HttpContext;
            return Ok(Array.Empty<string>());
        }
    }
}
