using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandUsuario
    {
        Task AgregarAsync(Usuario usuario);

        Task ModificarAsync(Usuario usuario);

        Task EliminarAsync(Guid id);
    }
}