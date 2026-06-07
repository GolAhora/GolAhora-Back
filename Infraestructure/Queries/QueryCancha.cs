using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces.Queries;
using Domain.Enums;

namespace Infrastructure.Queries
{
    public class QueryCancha : IQueryCancha
    {
        private readonly AppDbContext _context;
        public QueryCancha(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cancha?> ConsultarCanchaPorId(Guid id)
        {
            Cancha? cancha = await _context.Cancha.Include(c => c.TipoCancha)
                                                    .FirstOrDefaultAsync(c => c.Id == id);
            return cancha;

        }

        public async Task<IList<Cancha>> ConsultarCanchas()
        {
            IList<Cancha> canchas = await _context.Cancha.Include(c => c.TipoCancha).
                                                        ToListAsync<Cancha>();
            return canchas;
        }

        public async Task<bool> ConsultarDisponibildiad(Guid id)
        {
            Cancha? cancha = await _context.Cancha.Include(c => c.TipoCancha)
                                                    .FirstOrDefaultAsync(c => c.Id == id);

               return cancha?.Estado == EstadoCancha.Disponible;
        }



    }


}