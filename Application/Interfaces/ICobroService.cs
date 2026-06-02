using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICobroService
    {
        Task<CobroResponse> RegistrarCobro(CobroRequest request); 
        Task<CobroResponse> ModificarCobro(Guid id);
        Task<CobroResponse> ConsultarCobro(Guid id);
        Task<CobroResponse> EliminarCobro(Guid id);
        Task<CobroResponse> ImprimirCobro(Guid id);
        Task<CobroResponse> ValidarCobro(Guid id);
        Task<CobroResponse> GenerarReciboDeCobro(Guid id);
    }
}
