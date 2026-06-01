using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Response;

namespace Application.UseCases
{
    public class ServiceCobro : IServiceCobro
    {
        public Task<CobroResponse> ConsultarCobro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> ConsultarCobroPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> ConsultarCobroPorReserva(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> ConsultarCobroPorUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CobroResponse>> ConsultarCobros()
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> EliminarCobro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> ModificarCobro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> RealizarCobro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> RegistrarCobro(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
