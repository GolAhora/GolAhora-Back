using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryTipoCancha : IQueryTipoCancha
    {
        private readonly AppDbContext _context;

        public QueryTipoCancha(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TipoCancha?> ConsultarTipoCanchaPorId(Guid id)
        {
            return await _context.TipoCancha.FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public async Task<IList<TipoCancha>> ConsultarTiposCancha()
        {
            return await _context.TipoCancha.ToListAsync();
        }
    }
}
