using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mantenimiento
    {
        public Guid Id { get; set; }
        public Guid CanchaId { get; set; }
        public DateTime Fecha { get; set; }

        // ESTO DA EL ERROR: Asegurate de que digan TimeSpan
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public string? Motivo { get; set; }

        // ESTO DA EL ERROR: Asegurate de que diga string, no bool
        public string? Estado { get; set; }
    }
}