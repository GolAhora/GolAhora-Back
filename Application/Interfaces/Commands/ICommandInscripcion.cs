using Application.Models.Request;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandInscripcion
    {
       Task<Inscripcion> AgregarInscripcion(Inscripcion inscripcion);
       Task<Inscripcion> CancelarInscripcion(Guid id);
       Task<Inscripcion> ModificarInscripcion(Guid id, Inscripcion inscripcion);

    }
}