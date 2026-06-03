using System;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Queries
{
    public class QueryUsuario : IQueryUsuario
    {
        private readonly AppDbContext _context;
        public QueryUsuario(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ConsultarUsuario(Guid id)
        {
            Usuario? usuario = await  _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            return usuario;

        }

        public async Task<IList<Usuario>?> ConsultarUsuarioPorNombre(string nombre)
        {
            IList<Usuario>? usuarios = await _context.Usuario
                .Where(u => u.Nombre.Contains(nombre))
                .ToListAsync();

            if (usuarios == null || usuarios.Count == 0)
            {
                throw new Exception("No se encontraron usuarios");
            }

            return usuarios;
        }

        public async Task<IList<Usuario>> ConsultarUsuarios()
        {
            IList<Usuario> usuarios = await _context.Usuario.ToListAsync();

            if (usuarios == null || usuarios.Count == 0)
            {
                throw new Exception("No se encontraron usuarios");
            }

            return usuarios;
        }

    }


}