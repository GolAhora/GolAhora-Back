using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ServicePartido : IServicePartido

    {
        public Task<PartidoResponse> ConsultarPartidos()
        {
            throw new NotImplementedException();
        }
        public Task<PartidoResponse> ConsultarPartido(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<PartidoResponse> EliminarPartido(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<PartidoResponse> ModificarPartido(Guid id, PartidoRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<PartidoResponse> RegistrarPartido(PartidoRequest request)
        {
                throw new NotImplementedException();
        }

        public Task<PartidoResponse> RegistrarResultado(PartidoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PartidoResponse> ModificarResultado(Guid id, PartidoRequest request)
        {
            throw new NotImplementedException();
        }

        Task<PartidoResponse> IServicePartido.EliminarPartido(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<PartidoResponse> IServicePartido.ConsultarPartido(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PartidoResponse>> ConsultarPartidosPorCompetencia(Guid competenciaId)
        {
            throw new NotImplementedException();
        }
    }
}
