using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICompetenciaService
    {

        Task<CompetenciaResponse> OrganizarCompetencia(CompetenciaRequest request);
        Task<CompetenciaResponse> ModificarCompetencia(Guid id, CompetenciaRequest request);
        Task<CompetenciaResponse> EliminarCompetencia(Guid id);
       Task<IList<CompetenciaResponse>> ConsultarCompetencias();
        Task<CompetenciaResponse> ConsultarCompetencia(Guid id);
        Task<bool> IncribirUsario(Guid idCompetencia, Guid idUsuario);
        Task<CompetenciaResponse> ConsultarInscriptos();
        Task<CompetenciaResponse> GenerarFixture();
        Task<CompetenciaResponse> ConsultarFixture();

    }
}
