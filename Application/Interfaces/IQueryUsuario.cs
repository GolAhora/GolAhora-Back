using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryUsuario
    {
        Task<UsuarioResponse> ConsultarUsuario(Guid id);
        Task<IList<UsuarioResponse>> ConsultarUsuarios();
        Task<UsuarioResponse> EliminarUsuario();
        Task<UsuarioResponse> ModificarUsuario();
        Task<UsuarioResponse> Registrar();
    }
}
