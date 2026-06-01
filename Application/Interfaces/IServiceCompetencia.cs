using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceCompetencia
    {

        Task<CompetenciaResponse> RegistrarCompetencia(CompetenciaRequest request);
        Task<CompetenciaResponse> ModificarCompetencia(Guid id, CompetenciaRequest request);
        Task<CompetenciaResponse> EliminarCompetencia(Guid id);
        Task    <CompetenciaResponse> ConsultarCompetencia(Guid id);
        Task<IList<CompetenciaResponse>> ConsultarCompetencias();
        Task<CompetenciaResponse> AgregarActividadACompetencia(Guid idCompetencia, Guid idActividad);
        Task<CompetenciaResponse> EliminarActividadDeCompetencia(Guid idCompetencia, Guid idActividad);
        Task<CompetenciaResponse> AgregarUsuarioACompetencia(Guid idCompetencia, Guid idUsuario);
        Task<CompetenciaResponse> EliminarUsuarioDeCompetencia(Guid idCompetencia, Guid idUsuario);                                 


    }
}
