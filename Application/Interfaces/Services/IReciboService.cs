using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IReciboService
    {
        Task<ReciboResponse> ConsultarRecibo(Guid id);
        Task<IList<ReciboResponse>> ConsultarRecibos();
        Task<ReciboResponse> GenerarRecibo(ReciboRequest request);
        Task<ReciboResponse> ModificarRecibo(Guid id, ReciboRequest request);
        Task<ReciboResponse> EliminarRecibo(Guid id);
        Task<IList<ReciboResponse>> ConsultarRecibosPorUsuario(Guid idUsuario);
    }
}