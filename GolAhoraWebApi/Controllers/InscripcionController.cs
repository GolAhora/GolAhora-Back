using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionService _inscripcionService;

        public InscripcionController(IInscripcionService inscripcionService)
            => _inscripcionService = inscripcionService;


        [HttpPost]
        public async Task<IActionResult> AgregarInscripcion(InscripcionRequest request)
        {
            try
            {
                var res = await _inscripcionService.AgregarInscripcion(request);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarInscripcion(Guid id)
        {
            try
            {
                var res = await _inscripcionService.CancelarInscripcion(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // GET api/v1/competencia/{id}/inscriptos
        [HttpGet]
        public async Task<IActionResult> ConsultarInscriptos(Guid id)
        {
            // try
            // {
            //     var res = await _inscripcionService.(id);
            //     return new JsonResult(res) { StatusCode = 200 };
            // }
            // catch (Exception ex)
            // {
            //     return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            // }

            return new JsonResult("") { StatusCode = 200 };
        }
    
    }
}
