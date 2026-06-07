using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandPartido : ICommandPartido
    {
        private readonly AppDbContext _context;
        public CommandPartido(AppDbContext context) => _context = context;

        public async Task AgregarAsync(Partido partido)
        {
            partido.Id = Guid.NewGuid();
            await _context.Partido.AddAsync(partido);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Partido partido)
        {
            _context.Partido.Update(partido);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var p = await _context.Partido.FindAsync(id);
            if (p != null)
            {
                _context.Partido.Remove(p);
                await _context.SaveChangesAsync();
            }
        }
    }
}
