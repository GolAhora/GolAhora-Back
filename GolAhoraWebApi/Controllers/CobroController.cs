using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CobroController : ControllerBase
    {
        private readonly ICobroService _cobroService;

        public CobroController(ICobroService cobroService)
            => _cobroService = cobroService;

        [HttpGet]
        public async Task<IActionResult> ConsultarCobros()
        {
            try
            {
                var lista = await _cobroService.ConsultarCobros();
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarCobro(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _cobroService.ConsultarCobro(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpGet("fecha/{fecha}")]
        public async Task<IActionResult> ConsultarPorFecha(DateTime fecha)
        {
            try
            {
                var lista = await _cobroService.ConsultarCobroPorFecha(fecha);
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> ConsultarPorReserva(Guid idReserva)
        {
            try
            {
                var lista = await _cobroService.ConsultarCobroPorReserva(idReserva);
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> ConsultarPorUsuario(Guid idUsuario)
        {
            try
            {
                var lista = await _cobroService.ConsultarCobroPorUsuario(idUsuario);
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCobro(CobroRequest req)
        {
            try
            {
                var res = await _cobroService.RegistrarCobro(req);
                return new JsonResult(res) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCobro(Guid id, CobroRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _cobroService.ModificarCobro(id, req);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCobro(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _cobroService.EliminarCobro(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        // POST api/v1/cobro/{id}/validar
        [HttpPost("{id}/validar")]
        public async Task<IActionResult> ValidarCobro(Guid id)
        {
            try
            {
                var res = await _cobroService.ValidarCobro(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // POST api/v1/cobro/{id}/recibo
        [HttpPost("{id}/recibo")]
        public async Task<IActionResult> GenerarRecibo(Guid id)
        {
            try
            {
                var res = await _cobroService.GenerarReciboDeCobro(id);
                return new JsonResult(res) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
