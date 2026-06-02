using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServicePartido
    {
        Task<PartidoResponse> RegistrarPartido(PartidoRequest request);

        Task<PartidoResponse> ModificarPartido(Guid id, PartidoRequest request);

        Task<PartidoResponse> EliminarPartido(Guid id);

        Task<PartidoResponse> ConsultarPartido(Guid id);

        Task<IList<PartidoResponse>> ConsultarPartidos();
    }
}