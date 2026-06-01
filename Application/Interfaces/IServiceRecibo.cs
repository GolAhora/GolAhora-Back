using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceRecibo
    {
        Task<ReciboResponse> RealizarRecibo(Guid id);
        Task<ReciboResponse> ConsultarRecibo(Guid id);
        Task<IList<ReciboResponse>> ConsultarRecibos();
        Task<ReciboResponse> EliminarRecibo(Guid id);
        Task<ReciboResponse> ModificarRecibo(Guid id);
        Task<ReciboResponse> RegistrarRecibo(Guid id);
        Task<ReciboResponse> ConsultarReciboPorReserva(Guid id);
        Task<ReciboResponse> ConsultarReciboPorUsuario(Guid id);
        Task<ReciboResponse> ConsultarReciboPorFecha(DateTime fecha);
    }
}
