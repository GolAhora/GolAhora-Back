using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryUsuario
    {
        public Task<Usuario> Registrar(Usuario usuario);
        public Task<Usuario> ConsultarUsuario(Guid id);
        public Task<IList<Usuario>> ConsultarUsuarios();
        public Task<Usuario> EliminarUsuario(Guid id);
        public Task<Usuario> ModificarUsuario(Guid id, Usuario usuario);
 
    }
}
