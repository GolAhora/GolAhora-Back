using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Recibo
    {
        public Guid Id { get; set; }
        public int NumeroComprobante { get; set; }
        public DateTime  FechaEmision { get; set; }
        public Guid CobroId { get; set; }
        public Cobro Cobro { get; set; }

    }
}
