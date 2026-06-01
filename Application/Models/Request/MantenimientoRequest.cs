using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class MantenimientoRequest
    {
        public int? IdMantenimiento { get; set; }
        public int? IdCancha { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFin { get; set; } 
        public String? Motivo { get; set; }
        public Boolean? Estado { get; set; }
    }
}
