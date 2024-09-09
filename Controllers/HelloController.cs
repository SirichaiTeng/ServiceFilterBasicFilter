using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceFilterBasic.Models; // <-- using
namespace ServiceFilterBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {

        [HttpGet]
        [Route("getHello")]
        [ServiceFilter(typeof(ApiKeyAuthorizationFilter))]
        public IActionResult GetHello()
        {
            string result = "Hello World";
            return Ok(JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
