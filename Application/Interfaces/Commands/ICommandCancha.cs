using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandCancha
    {
        Task AgregarAsync(Cancha cancha);

        Task ModificarAsync(Cancha cancha);

        Task EliminarAsync(Guid id);
    }
}