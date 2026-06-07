using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandCobro : ICommandCobro
    {
        private readonly AppDbContext _context;
        public CommandCobro(AppDbContext context) => _context = context;

        public async Task AgregarAsync(Cobro cobro)
        {
            cobro.Id = Guid.NewGuid();
            await _context.Cobro.AddAsync(cobro);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Cobro cobro)
        {
            _context.Cobro.Update(cobro);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var c = await _context.Cobro.FindAsync(id);
            if (c != null)
            {
                _context.Cobro.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}
