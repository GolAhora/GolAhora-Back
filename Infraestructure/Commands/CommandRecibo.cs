using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandRecibo : ICommandRecibo
    {
        private readonly AppDbContext _context;
        public CommandRecibo(AppDbContext context) => _context = context;

        public async Task AgregarAsync(Recibo recibo)
        {
            recibo.Id = Guid.NewGuid();
            await _context.Recibo.AddAsync(recibo);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Recibo recibo)
        {
            _context.Recibo.Update(recibo);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var r = await _context.Recibo.FindAsync(id);
            if (r != null)
            {
                _context.Recibo.Remove(r);
                await _context.SaveChangesAsync();
            }
        }
    }
}
