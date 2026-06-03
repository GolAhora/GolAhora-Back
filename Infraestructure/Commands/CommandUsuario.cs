using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces.Commands;

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
            await  _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


    public async Task<Usuario?> ModificarUsuario(Guid id, Usuario usuario)
        {
            Usuario? update  = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
               if (update == null) return null;
       
             update.Nombre = usuario.Nombre ?? update.Nombre;
             update.Email = usuario.Email ?? update.Email;
             update.Password = usuario.Password ?? update.Password;
             await _context.SaveChangesAsync();

            return update;
        }
    public async Task<Usuario?> EliminarUsuario(Guid id)
        {
            Usuario? eliminar = await _context.Usuario.SingleOrDefaultAsync(u => u.Id == id);
            if (eliminar == null) return null;  

                _context.Usuario.Remove(eliminar);
                await _context.SaveChangesAsync();
                return eliminar;
        }

     

   
    }


}