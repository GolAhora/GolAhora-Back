using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces.Commands;

namespace Infrastructure.Commands
{
    public class CommandCancha : ICommandCancha
    {
        private readonly AppDbContext _context;
        public CommandCancha(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cancha> CrearCancha(Cancha cancha)
        {
            await  _context.Cancha.AddAsync(cancha);
            await _context.SaveChangesAsync();
            return cancha;
        }

        public async Task<Cancha?> EliminarCancha(Guid id)
             {
            Cancha? eliminar = await _context.Cancha.SingleOrDefaultAsync(c => c.Id == id);
            if (eliminar == null) return null;  

                _context.Cancha.Remove(eliminar);
                await _context.SaveChangesAsync();
                return eliminar;
        }


        public async Task<Cancha?> ModificarCancha(Guid id, Cancha cancha)
        {
            Cancha? modificar = await _context.Cancha.SingleOrDefaultAsync(c => c.Id == id);
            if (modificar == null) return null;

            modificar.Numero = cancha.Numero;
            modificar.Estado = cancha.Estado;
            modificar.TipoCancha = cancha.TipoCancha;

            await _context.SaveChangesAsync();
            return modificar;
        }
    }


}