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
    public class ServiceCancha : IServiceCancha
    {
        public Task<CanchaResponse> ActualizarCancha(Guid id, CanchaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarDisponibildiad(Guid id, bool disponible)
        {
            throw new NotImplementedException();
        }

        public Task<CanchaResponse> CancelarMantenimientoACancha(Guid idCancha, Guid idMantenimiento)
        {
            throw new NotImplementedException();
        }

        public Task<CanchaResponse> ConsultarCanchaPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CanchaResponse>> ConsultarCanchas()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConsultarDisponibildiad(Guid id, bool disponible)
        {
            throw new NotImplementedException();
        }

        public Task<CanchaResponse> ConsultarMantenimientoDeCancha(Guid idCancha)
        {
            throw new NotImplementedException();
        }

        public Task<CanchaResponse> CrearCancha(CanchaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CanchaResponse> EliminarCancha(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CanchaResponse> ProgramarMantenimientoACancha(Guid idCancha, Guid idMantenimiento)
        {
            throw new NotImplementedException();
        }
    }
}
