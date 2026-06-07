using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryPartido : IQueryPartido
    {
        private readonly AppDbContext _context;
        public QueryPartido(AppDbContext context) => _context = context;

        public async Task<Partido?> ObtenerPorIdAsync(Guid id)
            => await _context.Partido.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IList<Partido>> ObtenerTodosAsync()
            => await _context.Partido.ToListAsync();
    }
}
