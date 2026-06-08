using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        // GET api/v1/reserva
        [HttpGet]
        public async Task<IActionResult> ConsultarReservas()
        {
            try
            {
                var reservas = await _reservaService.ConsultarReservas();
                return new JsonResult(reservas) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }   



        

        [HttpGet("cancha/{idCancha}/reservas")]
        public async Task<IActionResult>  ConsultarReservasCancha(Guid idCancha)
        {
           try
            {
                 var reservas = await _reservaService.ConsultarReservasCancha(idCancha);

                 return new JsonResult(reservas) { StatusCode = 200 }; 
            }

             catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

           [HttpGet("cancha")]
        public async Task<IActionResult>  ConsultarReservaActiva([FromQuery] Guid idCancha)
        {
           try
            {
                 var reserva = await _reservaService.ConsultarReservaActiva(idCancha);

                 return new JsonResult(reserva) { StatusCode = 200 }; 
            }

             catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // GET api/v1/reserva/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarReservaPorId(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                ReservaResponse res = await _reservaService.ConsultarReserva(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        // POST api/v1/reserva
        [HttpPost]
        public async Task<IActionResult> CrearReserva(ReservaRequest req)
        {
            if (req.CanchaId == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "El ID de cancha es obligatorio." }) { StatusCode = 400 };

            if (String.IsNullOrEmpty(req.UsuarioId))
                return new JsonResult(new BadRequest { Message = "El ID de usuario es obligatorio." }) { StatusCode = 400 };

            try
            {
                ReservaResponse response = await _reservaService.CrearReserva(req);
                return new JsonResult(response) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // PUT api/v1/reserva/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarReserva(Guid id, ReservaRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                ReservaResponse response = await _reservaService.ModificarReserva(id, req);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // DELETE api/v1/reserva/{id}  →  soft-delete (cancela, no borra)
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarReserva(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                ReservaResponse response = await _reservaService.CancelarReserva(id);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
