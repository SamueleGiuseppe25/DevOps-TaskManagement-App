using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epita_2025_core_api_001_students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {message="Hello World"});

        }
        // 4 verbs for http requests: GET, POST, PUT, DELETE
        //codes 200 = ok, 404 = not found, 500 = internal server error
    }
}
