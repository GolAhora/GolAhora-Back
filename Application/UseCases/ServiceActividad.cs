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
        public Task<ActividadResponse> CancelarInscripcionPorUsuario(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ConsultarActividad(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ActividadResponse>> ConsultarActividades()
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ConsultarActividadPorCompetencia(Guid idCompetencia)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ConsultarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ConsultarFacturaPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ConsultarFacturaPorReserva(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ConsultarFacturaPorUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ActividadResponse>> ConsultarFacturas()
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> EliminarActividad(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> EliminarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ModificarActividad(ActividadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ModificarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ProgramarActividad(ActividadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> RealizarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> RegistrarFactura(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> ValidarCupoPorActividad(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
