using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryRecibo : IQueryRecibo
    {
        private readonly AppDbContext _context;
        public QueryRecibo(AppDbContext context) => _context = context;

        public async Task<Recibo?> ObtenerPorIdAsync(Guid id)
            => await _context.Recibo
                .Include(r => r.Cobro)
                .FirstOrDefaultAsync(r => r.Id == id);

        public async Task<IList<Recibo>> ObtenerTodosAsync()
            => await _context.Recibo.Include(r => r.Cobro).ToListAsync();

        public async Task<IList<Recibo>> ObtenerPorUsuarioAsync(Guid idUsuario)
        {
            // Recibo → Cobro → Reserva → Usuario
            var reservaIds = await _context.Reserva
                .Where(r => r.UsuarioId == idUsuario)
                .Select(r => r.Id)
                .ToListAsync();

            return await _context.Recibo
                .Include(r => r.Cobro)
                .Where(r => r.Cobro != null &&
                            r.Cobro.TipoReferencia == Domain.Enums.TipoReferencia.Reserva &&
                            reservaIds.Contains(r.Cobro.ReferenciaId))
                .ToListAsync();
        }
    }
}
