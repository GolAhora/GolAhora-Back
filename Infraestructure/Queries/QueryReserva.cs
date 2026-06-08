using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces.Queries;
using Domain.Enums;

namespace Infrastructure.Queries
{
    public class QueryReserva : IQueryReserva
    {
        private readonly AppDbContext _context;
        public QueryReserva(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Reserva>> ConsultarReservasCancha(Guid idCancha)
        {
            return await _context.Reserva
            .Include(r => r.Cancha)
            .ThenInclude(c => c.TipoCancha)
            .Where(r => r.CanchaId == idCancha)
            .ToListAsync();
        }

        public async Task<Reserva> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Reserva
                .Include(r => r.Cancha)
                .ThenInclude(c => c.TipoCancha)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IList<Reserva>> ObtenerTodosAsync()
        {
            return await _context.Reserva
                .Include(r => r.Cancha)
                .ThenInclude(c => c.TipoCancha)
                .ToListAsync();
        }
    }


}