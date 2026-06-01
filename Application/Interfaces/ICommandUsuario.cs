using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandUsuario
    {
        Task<UsuarioResponse> Registrar();
        Task<UsuarioResponse> ModificarUsuario();
        Task<UsuarioResponse> EliminarUsuario();
        Task<UsuarioResponse> ConsultarUsuario(Guid id);      
        Task<IList<UsuarioResponse>> ConsultarUsuarios();
    }
}
