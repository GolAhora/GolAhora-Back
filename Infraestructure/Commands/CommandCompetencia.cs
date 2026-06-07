using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandCompetencia : ICommandCompetencia
    {
        private readonly AppDbContext _context;
        public CommandCompetencia(AppDbContext context) => _context = context;

        public async Task AgregarAsync(Competencia competencia)
        {
            competencia.Id = Guid.NewGuid();
            await _context.Competencia.AddAsync(competencia);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Competencia competencia)
        {
            _context.Competencia.Update(competencia);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var c = await _context.Competencia.FindAsync(id);
            if (c != null)
            {
                _context.Competencia.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}
