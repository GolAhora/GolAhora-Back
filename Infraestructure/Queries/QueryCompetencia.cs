using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryCompetencia : IQueryCompetencia
    {
        private readonly AppDbContext _context;
        public QueryCompetencia(AppDbContext context) => _context = context;

        public async Task<Competencia?> ObtenerPorIdAsync(Guid id)
            => await _context.Competencia
                .Include(c => c.Inscripciones)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IList<Competencia>> ObtenerTodosAsync()
            => await _context.Competencia
                .Include(c => c.Inscripciones)
                .ToListAsync();
    }
}
