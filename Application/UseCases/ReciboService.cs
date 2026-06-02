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
    public class ReciboService : IReciboService
    {
        public Task<ReciboResponse> ConsultarRecibo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> ConsultarReciboPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> ConsultarReciboPorReserva(Guid idReserva)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> ConsultarReciboPorUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ReciboResponse>> ConsultarRecibos()
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> EliminarRecibo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> ModificarRecibo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> RealizarRecibo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> RegistrarRecibo(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
