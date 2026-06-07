using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {
        private readonly ICanchaService _canchaService;
        private readonly ITipoCanchaService _tipoCanchaService;

        private readonly IReservaService _reservaService;   

        public CanchaController(ICanchaService canchaService, ITipoCanchaService tipoCanchaService , IReservaService reservaService)
        {
            _canchaService = canchaService;
            _tipoCanchaService = tipoCanchaService;
            _reservaService = reservaService;

        }   

        [HttpGet]
        public async Task<IActionResult> ConsultarCanchas()
        {
            
            try
            {
                var canchas = await _canchaService.ConsultarCanchas();

                return new JsonResult(canchas) { StatusCode = 200 };
            }

            catch(Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 400 };

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarCanchaPorId(Guid id)
        {

                if (id == Guid.Empty)
                {
                    BadRequest badRequest = new BadRequest()
                    {
                        Message = "Ingreso un ID inválido"
                    };
                return new JsonResult(badRequest) { StatusCode = 400 };
                }

                CanchaResponse res = await _canchaService.ConsultarCanchaPorId(id);
            if (res == null)
            {
                BadRequest badRequest = new BadRequest()
                {
                    Message = $"No existe una mercaderia con el ID {id}"
                };
                return new JsonResult(badRequest) { StatusCode = 404 };
            }
                return new JsonResult(res) { StatusCode = 200 };
        }

        [HttpPost]
        public async Task<IActionResult> CrearCancha(CanchaRequest req)
        {
                  if (req.Numero == null || req.Numero <= 0)
                return new JsonResult(new BadRequest { Message = "Número de cancha inválido." }) { StatusCode = 400 };

                 var tipoCancha = await _tipoCanchaService.ConsultarTipoCanchaPorId(req.TipoCanchaId);
                if(tipoCancha == null)
                {
                    BadRequest badRequest = new BadRequest()
                    {
                        Message = "Tipo de cancha no válido"
                    };
                    return new JsonResult(badRequest) { StatusCode = 400 };
                }
                CanchaResponse response = await _canchaService.CrearCancha(req);
               return new JsonResult(response) {StatusCode = 201};    
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCanchaPorId(Guid id)
        {

                CanchaResponse res = await _canchaService.ConsultarCanchaPorId(id);
                if (res == null)
                    {
                        BadRequest badRequest = new BadRequest()
                        {
                            Message = $"No existe una cancha con el ID {id}"
                        };
                        return new JsonResult(badRequest) { StatusCode = 400 };
                    }
                IList<ReservaResponse> resReserva = await _reservaService.ConsultarReservasCancha(id);
                if (resReserva.Count > 0)
                {
                    BadRequest badRequest = new BadRequest()
                    {
                        Message = $"No se puede eliminar la cancha con ID {id} porque tiene reservas asociadas"
                    };
                    return new JsonResult(badRequest) { StatusCode = 409 };
                }

                CanchaResponse eliminar = await _canchaService.EliminarCancha(id);

                return new JsonResult(eliminar) { StatusCode = 200 };
     
        }


        ///  REVISAR 5/6
        ///  
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCancha(Guid id, CanchaRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                if (req.TipoCanchaId != Guid.Empty)
                {
                    var tipoCancha = await _tipoCanchaService.ConsultarTipoCanchaPorId(req.TipoCanchaId);
                    if (tipoCancha == null)
                        return new JsonResult(new BadRequest { Message = "Tipo de cancha no válido." }) { StatusCode = 400 };
                }

                CanchaResponse response = await _canchaService.ActualizarCancha(id, req);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }



    }
}
