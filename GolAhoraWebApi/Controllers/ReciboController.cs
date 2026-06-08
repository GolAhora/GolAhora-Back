using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private readonly IReciboService _reciboService;

        public ReciboController(IReciboService reciboService)
            => _reciboService = reciboService;

        [HttpGet]
        public async Task<IActionResult> ConsultarRecibos()
        {
            try
            {
                var lista = await _reciboService.ConsultarRecibos();
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarRecibo(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _reciboService.ConsultarRecibo(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> GenerarRecibo(ReciboRequest req)
        {
            try
            {
                var res = await _reciboService.GenerarRecibo(req);
                return new JsonResult(res) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarRecibo(Guid id, ReciboRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _reciboService.ModificarRecibo(id, req);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRecibo(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _reciboService.EliminarRecibo(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
