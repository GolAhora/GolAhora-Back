using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoCanchaController : ControllerBase
    {
        private readonly ITipoCanchaService _tipoCanchaService;

        public TipoCanchaController(ITipoCanchaService tipoCanchaService)
        {
            _tipoCanchaService = tipoCanchaService;
        }

        // GET api/v1/tipocancha
        [HttpGet]
        public async Task<IActionResult> ConsultarTiposCancha()
        {
            try
            {
                var tipos = await _tipoCanchaService.ConsultarTiposCancha();
                return new JsonResult(tipos) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // GET api/v1/tipocancha/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarTipoCanchaPorId(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                TipoCanchaResponse res = await _tipoCanchaService.ConsultarTipoCanchaPorId(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        // POST api/v1/tipocancha
        [HttpPost]
        public async Task<IActionResult> CrearTipoCancha(TipoCanchaRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Nombre))
                return new JsonResult(new BadRequest { Message = "El nombre del tipo de cancha es obligatorio." }) { StatusCode = 400 };

            try
            {
                TipoCanchaResponse response = await _tipoCanchaService.CrearTipoCancha(req);
                return new JsonResult(response) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // PUT api/v1/tipocancha/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTipoCancha(Guid id, TipoCanchaRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                TipoCanchaResponse response = await _tipoCanchaService.ActualizarTipoCancha(id, req);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // DELETE api/v1/tipocancha/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoCancha(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                TipoCanchaResponse response = await _tipoCanchaService.EliminarTipoCancha(id);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
