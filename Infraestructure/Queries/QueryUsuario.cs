using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces.Queries;

namespace Infrastructure.Queries
{
    public class QueryUsuario : IQueryUsuario
    {
        private readonly AppDbContext _context;
        public QueryUsuario(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ConsultarUsuarioPorId(Guid id)
        {
            Usuario? usuario = await  _context.Usuario.SingleOrDefaultAsync(u => u.Id == id);
            return usuario; 

        }

        public async Task<IList<Usuario>?> ConsultarUsuarioPorNombre(string nombre)
        {
            IList<Usuario>? usuarios = await _context.Usuario
                .Where(u => u.Nombre.Contains(nombre.Trim().ToLower()))
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

            return usuarios;
        }

    }


}