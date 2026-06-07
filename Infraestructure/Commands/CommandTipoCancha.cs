using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandTipoCancha : ICommandTipoCancha
    {
        private readonly AppDbContext _context;

        public CommandTipoCancha(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TipoCancha> CrearTipoCancha(TipoCancha tipoCancha)
        {
            await _context.TipoCancha.AddAsync(tipoCancha);
            await _context.SaveChangesAsync();
            return tipoCancha;
        }

        public async Task<TipoCancha?> ModificarTipoCancha(Guid id, TipoCancha tipoCancha)
        {
            TipoCancha? existente = await _context.TipoCancha.FirstOrDefaultAsync(tc => tc.Id == id);
            if (existente == null) return null;

            existente.Nombre = tipoCancha.Nombre;
            existente.Superficie = tipoCancha.Superficie;
            existente.Capacidad = tipoCancha.Capacidad;
            existente.DuracionMax = tipoCancha.DuracionMax;
            existente.PrecioBaseHora = tipoCancha.PrecioBaseHora;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<TipoCancha?> EliminarTipoCancha(Guid id)
        {
            TipoCancha? eliminar = await _context.TipoCancha.FirstOrDefaultAsync(tc => tc.Id == id);
            if (eliminar == null) return null;

            _context.TipoCancha.Remove(eliminar);
            await _context.SaveChangesAsync();
            return eliminar;
        }
    }
}
