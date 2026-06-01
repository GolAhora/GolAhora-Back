using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IServiceUsuario
    {

        Task<UsuarioResponse> Registrar();
        Task<UsuarioResponse> ModificarUsuario();
        Task<UsuarioResponse> EliminarUsuario();
        Task<UsuarioResponse> ConsultarUsuario(Guid id);
        Task<IList<UsuarioResponse>> ConsultarUsuarios();




    }
}
