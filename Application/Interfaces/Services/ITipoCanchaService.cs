using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITipoCanchaService
    {
       Task<TipoCanchaResponse> CrearTipoCancha(TipoCanchaRequest request);
       Task<TipoCanchaResponse> EliminarTipoCancha(Guid id);
       Task<TipoCanchaResponse> ActualizarTipoCancha(Guid id, TipoCanchaRequest request);
       Task<IList<TipoCanchaResponse>> ConsultarTiposCancha();
       Task<TipoCanchaResponse> ConsultarTipoCanchaPorId(Guid id);


    }
}
