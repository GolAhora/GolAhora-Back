using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICompetenciaService
    {

        Task<CompetenciaResponse> OrganizarCompetencia(CompetenciaRequest request);
        Task<CompetenciaResponse> ModificarCompetencia(Guid id, CompetenciaRequest request);
        Task<CompetenciaResponse> EliminarCompetencia(Guid id);
        Task<CompetenciaResponse> ConsultarCompetencia(Guid id);
        Task<IList<CompetenciaResponse>> IncribirUsario();
        Task<CompetenciaResponse> ConsultarInscriptos();
        Task<CompetenciaResponse> GenerarFixture();
        Task<CompetenciaResponse> ConsultarFixture();
        Task<CompetenciaResponse> RegistrarPartido();
        Task<CompetenciaResponse> ConsultarPartidos();
        Task<CompetenciaResponse> EliminarPartido(Guid id);
        Task<CompetenciaResponse> ModificarPartido(Guid id, CompetenciaRequest request);


    }
}
