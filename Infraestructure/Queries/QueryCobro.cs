using Application.Interfaces.Queries;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryCobro : IQueryCobro
    {
        private readonly AppDbContext _context;
        public QueryCobro(AppDbContext context) => _context = context;

        public async Task<Cobro?> ObtenerPorIdAsync(Guid id)
            => await _context.Cobro
                .Include(c => c.Recibo)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IList<Cobro>> ObtenerTodosAsync()
            => await _context.Cobro.Include(c => c.Recibo).ToListAsync();

        public async Task<IList<Cobro>> ObtenerPorFechaAsync(DateTime? fecha)
            => await _context.Cobro
                .Where(c => c.Fecha == fecha)
                .ToListAsync();

        public async Task<IList<Cobro>> ObtenerPorReservaAsync(Guid idReserva)
            => await _context.Cobro
                .Where(c => c.TipoReferencia == TipoReferencia.Reserva && c.ReferenciaId == idReserva)
                .ToListAsync();

        public async Task<IList<Cobro>> ObtenerPorUsuarioAsync(Guid idUsuario)
        {
            // Cobro no tiene FK directa a Usuario; se accede vía la Reserva referenciada
            var reservaIds = await _context.Reserva
                .Where(r => r.UsuarioId == idUsuario)
                .Select(r => r.Id)
                .ToListAsync();

            return await _context.Cobro
                .Where(c => c.TipoReferencia == TipoReferencia.Reserva &&
                            reservaIds.Contains(c.ReferenciaId))
                .ToListAsync();
        }
    }
}
