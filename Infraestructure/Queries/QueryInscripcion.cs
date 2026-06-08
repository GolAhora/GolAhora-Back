using Application.Interfaces.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class QueryInscripcion: IQueryInscripcion
    {
        private readonly AppDbContext _context;

        public QueryInscripcion(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Inscripcion> ConsultarInscripcion(Guid usuarioId)
        {
            var inscripcion = await _context.Inscripcion.FindAsync(usuarioId);
            return inscripcion;
        }
        public async Task<IList<Inscripcion>> ConsultarInscriptos(Guid idActividad)
        {
            var inscripciones = await _context.Inscripcion.Include(i => i.Actividad).Where(i => i.ReferenciaId == idActividad).ToListAsync();
            return inscripciones;
        }


    }
}
