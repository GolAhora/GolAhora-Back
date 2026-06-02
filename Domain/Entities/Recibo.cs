using System;

namespace Domain.Entities
{
    public class Recibo
    {
        public Guid Id { get; set; }
        public int NumeroComprobante { get; set; }
        public DateTime FechaEmision { get; set; }

        // ¡NUEVO! Faltaba el monto del recibo
        public decimal MontoTotal { get; set; }

        public Guid CobroId { get; set; }

        // Le agregamos el '?' para que no te tire warnings de nulos
        public Cobro? Cobro { get; set; }
    }
}