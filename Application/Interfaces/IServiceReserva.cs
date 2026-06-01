using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IServiceReserva
    {
        Task<ReservaResponse> CrearReserva(ReservaRequest request);
        Task<ReservaResponse> ModificarReserva(Guid id, ReservaRequest request);
        Task<ReservaResponse> CancelarReserva(Guid id);
        Task<ReservaResponse> ConsultarReserva(Guid id);
        Task<IList<ReservaResponse>> ConsultarReservas();

    }
}
