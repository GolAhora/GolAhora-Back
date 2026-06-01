using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CobroRequest
    {
        public int? IdCobro { get; set; }
        public DateTime? Fecha { get; set; }
        public string? MedioPago { get; set; }
        public float? MontoOriginal { get; set; }
        public float? MontoFinal { get; set; }
        public string? EstadoCobro { get; set; }
    }
}
