using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandActividad
    {
        Task AgregarAsync(Actividad actividad);

        Task ModificarAsync(Actividad actividad);

        Task EliminarAsync(Guid id);
    }
}