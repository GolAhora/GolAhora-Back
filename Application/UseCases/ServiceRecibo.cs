using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ServiceRecibo
    {
        public Task<ReciboResponse> GenerarRecibo(ReciboRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ReciboResponse> ConsultarRecibo(Guid id)
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
        public Task<ReciboResponse> ModificarRecibo(Guid id, ReciboRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<ReciboResponse> ConsultarRecibosPorUsuario(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
