using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: HomeController
        [HttpGet]
        public async Task<IActionResult> GetAll(string? fecha)
        {
                return new JsonResult("hola") { StatusCode = 200 };
        }

 
    }
}
