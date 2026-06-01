using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Response;

namespace Application.UseCases
{
    public class ServiceActividad : IServiceFactura
    {
        public Task<FacturaResponse> ConsultarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> ConsultarFacturaPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> ConsultarFacturaPorReserva(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> ConsultarFacturaPorUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FacturaResponse>> ConsultarFacturas()
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> EliminarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> ModificarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> RealizarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaResponse> RegistrarFactura(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
