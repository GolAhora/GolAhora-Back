using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asistencia
    {
        public Guid Id { get; set; }
        public DateTime FechaHorario { get; set; }
        public Guid ActividadId { get; set; }
        public Guid PersonaId { get; set; }
        public Persona Persona { get; set; }
        public Actividad Actividad { get; set; }

    }
}
