using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET api/v1/usuario
        [HttpGet]
        public async Task<IActionResult> ConsultarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.ConsultarUsuarios();
                return new JsonResult(usuarios) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // GET api/v1/usuario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarUsuarioPorId(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                UsuarioResponse res = await _usuarioService.ConsultarUsuario(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        // POST api/v1/usuario
        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return new JsonResult(new BadRequest { Message = "El email es obligatorio." }) { StatusCode = 400 };

            try
            {
                UsuarioResponse response = await _usuarioService.Registrar(req);
                return new JsonResult(response) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // PUT api/v1/usuario/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarUsuario(Guid id, UsuarioRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                UsuarioResponse response = await _usuarioService.ModificarUsuario(id, req);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // DELETE api/v1/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "Ingresó un ID inválido." }) { StatusCode = 400 };

            try
            {
                UsuarioResponse response = await _usuarioService.EliminarUsuario(id);
                return new JsonResult(response) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
