using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceUsuario
    {
        Task<UsuarioResponse> Registrar(UsuarioRequest request); 
        Task<UsuarioResponse> ModificarUsuario(Guid id, UsuarioRequest request); 
        Task<UsuarioResponse> EliminarUsuario(Guid id); 
        Task<UsuarioResponse> ConsultarUsuario(Guid id);
        Task<IList<UsuarioResponse>> ConsultarUsuarios();
    }
}
