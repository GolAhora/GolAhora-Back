using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservaService 
    {
        Task<ReservaResponse> CrearReserva(ReservaRequest request);
        Task<ReservaResponse> ModificarReserva(Guid id, ReservaRequest request);
        Task<ReservaResponse> CancelarReserva(Guid id);
        Task<ReservaResponse> ConsultarReserva(Guid id);
        Task<IList<ReservaResponse>> ConsultarReservas();
    }
}
