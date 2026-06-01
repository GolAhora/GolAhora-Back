using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceCancha
    {
       Task<CanchaResponse> CrearCancha(CanchaRequest request);
       Task<CanchaResponse> EliminarCancha(Guid id);
       Task<Boolean> ActualizarDisponibildiad(Guid id, bool disponible);
       Task<CanchaResponse> ActualizarCancha(Guid id, CanchaRequest request);
       Task<IList<CanchaResponse>> ConsultarCanchas();
       Task<CanchaResponse> ConsultarCanchaPorId(Guid id);

    }
}
