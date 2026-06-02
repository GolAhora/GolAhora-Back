using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar todas las operaciones relacionadas con Usuarios
    public class ServiceUsuario : IServiceUsuario
    {
        // Query se utiliza para consultar información
        private readonly IQueryUsuario _query;

        // Command se utiliza para guardar, modificar y eliminar información
        private readonly ICommandUsuario _command;

        // Constructor
        public ServiceUsuario(IQueryUsuario query, ICommandUsuario command)
        {
            _query = query;
            _command = command;
        }

        // Consulta un usuario por Id
        public async Task<UsuarioResponse> ConsultarUsuario(Guid id)
        {
            Usuario usuario = await _query.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                throw new Exception("El usuario no existe.");
            }

            return Mapear(usuario);
        }

        // Consulta todos los usuarios
        public async Task<IList<UsuarioResponse>> ConsultarUsuarios()
        {
            IList<Usuario> usuarios = await _query.ObtenerTodosAsync();

            List<UsuarioResponse> listaUsuarios = new List<UsuarioResponse>();

            foreach (Usuario usuario in usuarios)
            {
                listaUsuarios.Add(Mapear(usuario));
            }

            return listaUsuarios;
        }

        // Registra un nuevo usuario
        public async Task<UsuarioResponse> Registrar(UsuarioRequest request)
        {
            // Validación simple
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new Exception("El email es obligatorio.");
            }

            Usuario nuevoUsuario = new Usuario();

            nuevoUsuario.Nombre = request.Nombre;
            nuevoUsuario.Direccion = request.Direccion;
            nuevoUsuario.Telefono = request.Telefono;
            nuevoUsuario.Email = request.Email;

            await _command.AgregarAsync(nuevoUsuario);

            return Mapear(nuevoUsuario);
        }

        // Modifica un usuario existente
        public async Task<UsuarioResponse> ModificarUsuario(Guid id, UsuarioRequest request)
        {
            Usuario usuarioExistente = await _query.ObtenerPorIdAsync(id);

            if (usuarioExistente == null)
            {
                throw new Exception("El usuario que intenta modificar no existe.");
            }

            usuarioExistente.Nombre = request.Nombre;
            usuarioExistente.Direccion = request.Direccion;
            usuarioExistente.Telefono = request.Telefono;
            usuarioExistente.Email = request.Email;

            await _command.ModificarAsync(usuarioExistente);

            return Mapear(usuarioExistente);
        }

        // Elimina un usuario
        public async Task<UsuarioResponse> EliminarUsuario(Guid id)
        {
            Usuario usuario = await _query.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                throw new Exception("El usuario que intenta eliminar no existe.");
            }

            await _command.EliminarAsync(id);

            return Mapear(usuario);
        }


        // Método privado que convierte una entidad Usuario
        // en un objeto UsuarioResponse
        private UsuarioResponse Mapear(Usuario usuario)
        {
            UsuarioResponse respuesta = new UsuarioResponse();

            respuesta.Id = usuario.Id;
            respuesta.Nombre = usuario.Nombre;
            respuesta.Direccion = usuario.Direccion;
            respuesta.Telefono = usuario.Telefono;
            respuesta.Email = usuario.Email;

            return respuesta;
        }
    }
}