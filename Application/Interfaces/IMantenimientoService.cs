using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IMantenimientoService
    {
        Task<MantenimientoResponse> RegistrarMantenimiento(MantenimientoRequest request);
        Task<MantenimientoResponse> ModificarMantenimiento(Guid id, MantenimientoRequest request);
        Task<MantenimientoResponse> EliminarMantenimiento(Guid id);
        Task<MantenimientoResponse> ConsultarMantenimiento(Guid id);
        Task<IList<MantenimientoResponse>> ConsultarMantenimientos();
        Task<MantenimientoResponse> AgregarCanchaAMantenimiento(Guid idMantenimiento, Guid idCancha);

    }
}
