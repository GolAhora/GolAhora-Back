using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class MantenimientoRequest
    {
        public Guid CanchaId { get; set; } // Fundamental saber qué cancha bloqueamos
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Motivo { get; set; }
    }
}
