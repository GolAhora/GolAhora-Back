using System;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Queries
{
    public class QueryCancha : IQueryCancha
    {
        private readonly AppDbContext _context;
        public QueryCancha(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cancha> ConsultarCanchaPorId(Guid id)
        {
            Cancha? cancha = await _context.Cancha.FindAsync(id);
            if (cancha == null)
            {
                throw new Exception("Cancha no encontrada");
            }

            return cancha;

        }

        public async Task<IList<Cancha>> ConsultarCanchas()
        {
            IList<Cancha> canchas = await _context.Cancha.ToListAsync<Cancha>();
            if (canchas == null || canchas.Count == 0)
            {
                throw new Exception("No se encontraron canchas");
            }

            return canchas;
        }

        public async Task<bool> ConsultarDisponibildiad(Guid id)
        {
            Cancha? cancha = await _context.Cancha.FirstOrDefaultAsync(c => c.Id == id);

              if (cancha == null)
            {
                throw new Exception("Cancha no encontrada");
            }

           return cancha.Disponible;
        }

        public async Task<Cancha> ConsultarMantenimientoDeCancha(Guid id)
        {
            Cancha? cancha = await _context.Cancha.Include(c => );
            if (cancha == null)
            {
                throw new Exception("Cancha no encontrada");
            }

            return cancha;
        }
    }


}