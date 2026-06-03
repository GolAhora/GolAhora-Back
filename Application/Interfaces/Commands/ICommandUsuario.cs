using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandUsuario
    {
        Task<Usuario> Registrar(Usuario usuario);

        Task<Usuario?> ModificarUsuario(Guid id, Usuario usuario);

        Task<Usuario?> EliminarUsuario(Guid id);
    }
}