using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class MantenimientoResponse
    {
        public Guid Id { get; set; }
        public string? Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string? Estado { get; set; }
        public Guid CanchaId { get; set; } // Una sola cancha
    }
}
