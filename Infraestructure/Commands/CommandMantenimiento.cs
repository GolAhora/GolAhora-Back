using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandMantenimiento : ICommandMantenimiento
    {
        private readonly AppDbContext _context;
        public CommandMantenimiento(AppDbContext context) => _context = context;

        public async Task AgregarAsync(Mantenimiento mantenimiento)
        {
            mantenimiento.Id = Guid.NewGuid();
            await _context.Mantenimiento.AddAsync(mantenimiento);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Mantenimiento mantenimiento)
        {
            _context.Mantenimiento.Update(mantenimiento);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var m = await _context.Mantenimiento.FindAsync(id);
            if (m != null)
            {
                _context.Mantenimiento.Remove(m);
                await _context.SaveChangesAsync();
            }
        }
    }
}
