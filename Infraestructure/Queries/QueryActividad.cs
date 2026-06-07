using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class QueryActividad : IQueryActividad
    {
        private readonly AppDbContext _context;
        public QueryActividad(AppDbContext context) => _context = context;

        public async Task<Actividad?> ObtenerPorIdAsync(Guid id)
            => await _context.Actividad
                .Include(a => a.Inscripciones)
                .Include(a => a.Cancha)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IList<Actividad>> ObtenerTodosAsync()
            => await _context.Actividad
                .Include(a => a.Inscripciones)
                .Include(a => a.Cancha)
                .ToListAsync();

        public async Task<IList<Actividad>> ObtenerPorCompetenciaAsync(Guid idCompetencia)
            => await _context.Actividad
                .Include(a => a.Inscripciones)
                .Where(a => a.Inscripciones.Any(i =>
                    i.TipoInscripcion == Domain.Enums.TipoInscripcion.Competencia &&
                    i.ReferenciaId    == idCompetencia))
                .ToListAsync();
    }
}
