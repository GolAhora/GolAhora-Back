using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.UseCases
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IQueryUsuario _query;     
        private readonly ICommandUsuario _command;

        public ServiceUsuario(IQueryUsuario query, ICommandUsuario command) 
        {
            _query = query;
            _command = command;

        }

        public Task<UsuarioResponse> ConsultarUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UsuarioResponse>> ConsultarUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> EliminarUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> EliminarUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> ModificarUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> ModificarUsuario(Guid id, UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Registrar()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> Registrar(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
