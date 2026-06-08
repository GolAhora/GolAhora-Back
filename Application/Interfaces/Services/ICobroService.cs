using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICobroService
    {
        Task<CobroResponse> RegistrarCobro(CobroRequest request);
        Task<CobroResponse> ModificarCobro(Guid id, CobroRequest request);
        Task<IList<CobroResponse>> ConsultarCobros(DateTime fecha);
        Task<CobroResponse> ConsultarCobro(Guid id);
        Task<CobroResponse> EliminarCobro(Guid id);
        Task<ReciboResponse> GenerarReciboDeCobro(Guid id); 

    }
}
