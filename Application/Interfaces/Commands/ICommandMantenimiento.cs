using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandMantenimiento
    {
        Task AgregarAsync(Mantenimiento mantenimiento);

        Task ModificarAsync(Mantenimiento mantenimiento);

        Task EliminarAsync(Guid id);
    }
}