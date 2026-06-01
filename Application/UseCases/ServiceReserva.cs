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
    public class ServiceReserva : IServiceReserva
    {
        public Task<ReservaResponse> CancelarReserva(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReservaResponse> ConsultarReserva(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ReservaResponse>> ConsultarReservas()
        {
            throw new NotImplementedException();
        }

        public Task<ReservaResponse> CrearReserva(ReservaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ReservaResponse> ModificarReserva(Guid id, ReservaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ReservaResponse> RegistrarReserva(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
