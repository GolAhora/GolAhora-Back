using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IActividadService _actividadService;

        public ActividadController(IActividadService actividadService)
            => _actividadService = actividadService;

        [HttpGet]
        public async Task<IActionResult> ConsultarActividades()
        {
            try
            {
                var lista = await _actividadService.ConsultarActividades();
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarActividad(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _actividadService.ConsultarActividad(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProgramarActividad(ActividadRequest req)
        {
            try
            {
                var res = await _actividadService.ProgramarActividad(req);
                return new JsonResult(res) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarActividad(Guid id, ActividadRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _actividadService.ModificarActividad(id, req);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarActividad(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _actividadService.EliminarActividad(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
