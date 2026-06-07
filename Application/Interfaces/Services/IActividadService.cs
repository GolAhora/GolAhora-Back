using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IActividadService
    {

        Task<ActividadResponse> ProgramarActividad(ActividadRequest request);
        Task<ActividadResponse> ModificarActividad(Guid id, ActividadRequest request);
        Task<ActividadResponse> EliminarActividad(Guid id);
        Task<ActividadResponse> ConsultarActividad(Guid id);
        Task<ActividadResponse> ValidarCupoPorActividad(Guid idUsuario);
        Task<IList<ActividadResponse>> ConsultarActividades();

    }
}
