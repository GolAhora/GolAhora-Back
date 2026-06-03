using System;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class CommandUsuario : ICommandUsuario
    {
        private readonly AppDbContext _context;
        public CommandUsuario(AppDbContext context)
        {
            _context = context;
        }

     public async Task<Usuario> Registrar(Usuario usuario)
        {
            Usuario nuevoUsuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password
            };
            _context.Usuario.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return nuevoUsuario;
        }


    public async Task<Usuario> ModificarUsuario(Guid id, Usuario usuario)
        {
            Usuario? usuarioEncontrado = await _context.Usuario.FindAsync(id);
            if (usuarioEncontrado == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            
            Usuario usuarioModificado = new Usuario
            {

                Id = id,
                Nombre = usuario.Nombre ?? usuarioEncontrado.Nombre,
                Email = usuario.Email ?? usuarioEncontrado.Email,
                Password = usuario.Password ?? usuarioEncontrado.Password
            };
             //  _context.Entry(usuarioEncontrado).CurrentValues.SetValues(usuarioModificado);
            _context.SaveChanges();
            return usuarioModificado;
        }
    public async Task<Usuario> EliminarUsuario(Guid id)
        {
            Usuario? usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

                _context.Usuario.Remove(usuario);
                _context.SaveChanges();

                return usuario;
        }

     

   
    }


}