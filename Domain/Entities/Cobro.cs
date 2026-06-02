using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
     public class Cobro
    {
        public Guid Id { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoReferencia TipoReferencia { get; set; }
        public DateTime Fecha { get; set; }
        public String MedioPago { get; set; }
        public float MontoOriginal { get; set; }
        public float MontoFinal { get; set; }
        public Estado Estado { get; set; }
        public Recibo? Recibo { get; set; }

    }

}

