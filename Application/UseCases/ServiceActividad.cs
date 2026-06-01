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
    public class ServiceActividad : IServiceActividad
    {
        public Task<ActividadResponse> ConsultarActividad(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ActividadResponse>> ConsultarActividades()
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> EliminarActividad(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ModificarActividad(ActividadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> Registrar(ActividadRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
