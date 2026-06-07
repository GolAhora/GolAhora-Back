using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GolAhoraWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompetenciaController : ControllerBase
    {
        private readonly ICompetenciaService _competenciaService;

        public CompetenciaController(ICompetenciaService competenciaService)
            => _competenciaService = competenciaService;

        [HttpGet]
        public async Task<IActionResult> ConsultarCompetencias()
        {
            try
            {
                var lista = await _competenciaService.ConsultarCompetencias();
                return new JsonResult(lista) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarCompetencia(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _competenciaService.ConsultarCompetencia(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrganizarCompetencia(CompetenciaRequest req)
        {
            try
            {
                var res = await _competenciaService.OrganizarCompetencia(req);
                return new JsonResult(res) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCompetencia(Guid id, CompetenciaRequest req)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _competenciaService.ModificarCompetencia(id, req);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCompetencia(Guid id)
        {
            if (id == Guid.Empty)
                return new JsonResult(new BadRequest { Message = "ID inválido." }) { StatusCode = 400 };
            try
            {
                var res = await _competenciaService.EliminarCompetencia(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        // POST api/v1/competencia/{id}/inscripcion/{idUsuario}
        [HttpPost("{id}/inscripcion/{idUsuario}")]
        public async Task<IActionResult> InscribirUsuario(Guid idCompetencia, Guid idUsuario)
        {
            try
            {
                var res = await _competenciaService.IncribirUsario(id, idUsuario);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // DELETE api/v1/competencia/{id}/inscripcion/{idUsuario}
        [HttpDelete("{id}/inscripcion/{idUsuario}")]
        public async Task<IActionResult> EliminarInscripcion(Guid id, Guid idUsuario)
        {
            try
            {
                var res = await _competenciaService.EliminarUsuarioDeCompetencia(id, idUsuario);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // GET api/v1/competencia/{id}/inscriptos
        [HttpGet("{id}/inscriptos")]
        public async Task<IActionResult> ConsultarInscriptos(Guid id)
        {
            try
            {
                var res = await _competenciaService.ConsultarInscriptos(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        // POST api/v1/competencia/{id}/fixture
        [HttpPost("{id}/fixture")]
        public async Task<IActionResult> GenerarFixture(Guid id)
        {
            try
            {
                var res = await _competenciaService.GenerarFixture(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        // GET api/v1/competencia/{id}/fixture
        [HttpGet("{id}/fixture")]
        public async Task<IActionResult> ConsultarFixture(Guid id)
        {
            try
            {
                var res = await _competenciaService.ConsultarFixture(id);
                return new JsonResult(res) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
