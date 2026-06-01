using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.UseCases
{
    public class ServiceCompetencia : IServiceCompetencia
    {
        public Task<CompetenciaResponse> AgregarActividadACompetencia(Guid idCompetencia, Guid idActividad)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> AgregarUsuarioACompetencia(Guid idCompetencia, Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ConsultarCompetencia(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CompetenciaResponse>> ConsultarCompetencias()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ConsultarFixture()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ConsultarInscriptos()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ConsultarPartidos()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> EliminarActividadDeCompetencia(Guid idCompetencia, Guid idActividad)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> EliminarCompetencia(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> EliminarPartido(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> EliminarUsuarioDeCompetencia(Guid idCompetencia, Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> GenerarFixture()
        {
            throw new NotImplementedException();
        }

        public Task<IList<CompetenciaResponse>> IncribirUsario()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ModificarCompetencia(Guid id, CompetenciaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ModificarPartido(Guid id, CompetenciaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> OrganizarCompetencia(CompetenciaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> RegistrarCompetencia(CompetenciaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> RegistrarPartido()
        {
            throw new NotImplementedException();
        }
    }
}
