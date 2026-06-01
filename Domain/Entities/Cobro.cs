using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class Cobro
    {
        public Guid Id { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoReferencia TipoReferencia { get; set; }
        public TimeSpan Fecha { get; set; }
        public String MedioPago { get; set; }
        public float MontoOriginal { get; set; }
        public float MontoFinal { get; set; }
        public EstadoCobro Estado { get; set; }
        public Factura? Factura { get; set; }

    }

}

public enum EstadoCobro
{
    Pendiente = 1,
    Confirmada = 2,
    Cancelada = 3
}


public enum TipoReferencia
{
    Reserva = 1,
    Inscripcion = 2,
 
}