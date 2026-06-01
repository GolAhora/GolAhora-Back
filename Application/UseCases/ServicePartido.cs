using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ServicePartido
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


    }
}
