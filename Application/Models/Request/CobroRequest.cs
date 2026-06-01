using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CobroRequest
    {
        public Guid ReferenciaId { get; set; } // Puede ser el ID de una Reserva o de una Inscripción
        public string? MedioPago { get; set; } // "Efectivo", "Debito", "Credito"
        public decimal MontoFinal { get; set; }
    }
}
