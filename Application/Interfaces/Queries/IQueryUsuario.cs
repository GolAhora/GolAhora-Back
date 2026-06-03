using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryUsuario
    {
        Task<Usuario?> ConsultarUsuarioPorId(Guid id);
        Task<IList<Usuario>> ConsultarUsuarios();
        Task<IList<Usuario>?> ConsultarUsuarioPorNombre(string nombre);
    }
}