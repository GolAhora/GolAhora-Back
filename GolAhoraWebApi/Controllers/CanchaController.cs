using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{


    [Route("api/v1/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {
        private readonly ICanchaService _canchaService;


        public CanchaController(ICanchaService canchaService )
        {
            _canchaService = canchaService;

        }   

        [HttpGet]
        public async Task<IActionResult> GetAll(string? fecha)
        {
            var canchas = await _canchaService.ConsultarCanchas();


            return new JsonResult(canchas) { StatusCode = 200 };
        }

    }
}
