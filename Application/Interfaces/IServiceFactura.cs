using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceFactura
    {
        Task<FacturaResponse> RealizarFactura(Guid id);
        Task<FacturaResponse> ConsultarFactura(Guid id);
        Task<IList<FacturaResponse>> ConsultarFacturas();
        Task<FacturaResponse> EliminarFactura(Guid id);
        Task<FacturaResponse> ModificarFactura(Guid id);
        Task<FacturaResponse> RegistrarFactura(Guid id);
        Task<FacturaResponse> ConsultarFacturaPorReserva(Guid id);
        Task<FacturaResponse> ConsultarFacturaPorUsuario(Guid id);
        Task<FacturaResponse> ConsultarFacturaPorFecha(DateTime fecha);
    }
}
