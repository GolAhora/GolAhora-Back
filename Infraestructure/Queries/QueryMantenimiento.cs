using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryMantenimiento : IQueryMantenimiento
    {
        private readonly AppDbContext _context;
        public QueryMantenimiento(AppDbContext context) => _context = context;

        public async Task<Mantenimiento?> ObtenerPorIdAsync(Guid id)
            => await _context.Mantenimiento
                .Include(m => m.Cancha)
                .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<IList<Mantenimiento>> ObtenerTodosAsync()
            => await _context.Mantenimiento
                .Include(m => m.Cancha)
                .ToListAsync();
    }
}
