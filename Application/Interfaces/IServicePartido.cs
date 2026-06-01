using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPartidoService
    {
        Task<PartidoResponse> RegistrarResultado(PartidoRequest request);
        Task<PartidoResponse> ModificarResultado(Guid id, PartidoRequest request);
        Task<PartidoResponse> EliminarPartido(Guid id);
        Task<PartidoResponse> ConsultarPartido(Guid id);
        Task<IList<PartidoResponse>> ConsultarPartidosPorCompetencia(Guid competenciaId);
    }
}