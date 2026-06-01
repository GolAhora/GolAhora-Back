using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoInscripcion TipoInscripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public List<Asistencia> Asistencias { get; set; }
    }
}
public enum TipoInscripcion
{
    Actividad = 1,
    Competencia = 2
}