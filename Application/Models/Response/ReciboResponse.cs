using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class ReciboResponse
    {
        public Guid Id { get; set; }
        public int NumeroComprobante { get; set; } // Clave para la impresión
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public Guid CobroId { get; set; }
    }
}
