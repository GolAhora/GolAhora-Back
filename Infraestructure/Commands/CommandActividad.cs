using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandActividad : ICommandActividad
    {
        private readonly AppDbContext _context;
        public CommandActividad(AppDbContext context) => _context = context;

        public async Task AgregarAsync(Actividad actividad)
        {
            actividad.Id = Guid.NewGuid();
            await _context.Actividad.AddAsync(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Actividad actividad)
        {
            _context.Actividad.Update(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var a = await _context.Actividad.FindAsync(id);
            if (a != null)
            {
                _context.Actividad.Remove(a);
                await _context.SaveChangesAsync();
            }
        }
    }
}
