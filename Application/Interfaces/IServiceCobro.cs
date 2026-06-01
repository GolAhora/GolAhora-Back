using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceCobro
    {
        Task<CobroResponse> RealizarCobro(Guid id);
        Task<CobroResponse> ConsultarCobro(Guid id);
        Task<IList<CobroResponse>> ConsultarCobros();
        Task<CobroResponse> EliminarCobro(Guid id);
        Task<CobroResponse> ModificarCobro(Guid id);
        Task<CobroResponse> RegistrarCobro(Guid id);
        Task<CobroResponse> ConsultarCobroPorReserva(Guid id);
        Task<CobroResponse> ConsultarCobroPorUsuario(Guid id);
        Task<CobroResponse> ConsultarCobroPorFecha(DateTime fecha);


    }
}
