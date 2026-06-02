using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
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
    // Servicio encargado de ser el "cerebro" de los Usuarios
    public class UsuarioService : IUsuarioService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryUsuario _query;     
        private readonly ICommandUsuario _command;

        // Constructor: C# inyecta estas herramientas automáticamente
        public UsuarioService(IQueryUsuario query, ICommandUsuario command) 
        {
            _query = query;
            _command = command;

        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<UsuarioResponse> ConsultarUsuario(Guid id)
        {
            var usuario = await _query.ObtenerPorIdAsync(id);

            if (usuario == null) throw new Exception("El usuario no existe.");

            return Mapear(usuario);
        }

        public async Task<IList<UsuarioResponse>> ConsultarUsuarios()
        {
            var usuarios = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista a Response en un solo paso
            return usuarios.Select(Mapear).ToList();
        }

        public async Task<UsuarioResponse> Registrar(UsuarioRequest request)
        {
            // Regla de negocio: El email es un dato vital
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new Exception("El email es obligatorio para registrarse.");
        }

            // Armamos el usuario nuevo completo en un solo bloque (Object Initializer)
            var nuevoUsuario = new Usuario
        {
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Email = request.Email
            };

            await _command.AgregarAsync(nuevoUsuario);

            return Mapear(nuevoUsuario);
        }

        public async Task<UsuarioResponse> ModificarUsuario(Guid id, UsuarioRequest request)
        {
            var usuarioExistente = await _query.ObtenerPorIdAsync(id);

            if (usuarioExistente == null) throw new Exception("El usuario que intenta modificar no existe.");

            // Pisamos los datos permitidos
            usuarioExistente.Nombre = request.Nombre;
            usuarioExistente.Direccion = request.Direccion;
            usuarioExistente.Telefono = request.Telefono;
            usuarioExistente.Email = request.Email;

            await _command.ModificarAsync(usuarioExistente);

            return Mapear(usuarioExistente);
        }

        public async Task<UsuarioResponse> EliminarUsuario(Guid id)
        {
            var usuario = await _query.ObtenerPorIdAsync(id);

            if (usuario == null) throw new Exception("El usuario que intenta eliminar no existe.");

            await _command.EliminarAsync(id);

            return Mapear(usuario);
        }


        // --- 2. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la entidad de la BD en un objeto seguro para enviar a la pantalla web
        private UsuarioResponse Mapear(Usuario usuario)
        {
            return new UsuarioResponse
        {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            };
        }
    }
}
