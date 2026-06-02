using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICanchaService
    {
       Task<CanchaResponse> CrearCancha(CanchaRequest request);
       Task<CanchaResponse> EliminarCancha(Guid id);
       Task<Boolean> ConsultarDisponibildiad(Guid id, bool disponible);
       Task<CanchaResponse> ActualizarCancha(Guid id, CanchaRequest request);
       Task<IList<CanchaResponse>> ConsultarCanchas();
       Task<CanchaResponse> ConsultarCanchaPorId(Guid id);
       Task<CanchaResponse> ProgramarMantenimientoACancha(Guid idCancha, Guid idMantenimiento);
       Task<CanchaResponse> CancelarMantenimientoACancha(Guid idCancha, Guid idMantenimiento);
       Task<CanchaResponse> ConsultarMantenimientoDeCancha(Guid idCancha);

    }
}
