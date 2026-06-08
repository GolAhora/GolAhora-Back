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


        public async Task<Reserva?> ConsularReservaActiva(Guid canchaId)
        {
            var ahora = DateTime.Now;
            return await _context.Reserva
                .Where(r =>
                    r.CanchaId == canchaId &&
                    r.Fecha.Date == ahora.Date &&
                    r.HoraInicio <= ahora.TimeOfDay &&
                    r.HoraFin >= ahora.TimeOfDay)
                .FirstOrDefaultAsync();
        }

        public Task<Reserva> ObtenerPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Reserva>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }


}