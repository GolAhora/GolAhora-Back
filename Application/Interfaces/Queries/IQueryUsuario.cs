using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryUsuario
    {
        Task<Usuario> ObtenerPorIdAsync(Guid id);

        Task<IList<Usuario>> ObtenerTodosAsync();

        Task<Usuario> EliminarUsuario();

        Task<Usuario> ModificarUsuario();

        Task<Usuario> Registrar();
    }
}