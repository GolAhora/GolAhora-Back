using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.UseCases
{
    public class MantenimientoService : IMantenimientoService
    {
        public Task<MantenimientoResponse> AgregarCanchaAMantenimiento(Guid idMantenimiento, Guid idCancha)
        {
            throw new NotImplementedException();
        }

        public Task<MantenimientoResponse> ConsultarMantenimiento(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MantenimientoResponse>> ConsultarMantenimientos()
        {
            throw new NotImplementedException();
        }

        public Task<MantenimientoResponse> EliminarMantenimiento(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MantenimientoResponse> ModificarMantenimiento(Guid id, MantenimientoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<MantenimientoResponse> RegistrarMantenimiento(MantenimientoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
