using System;

namespace Domain.Entities
{
    public class Cobro
    {
        public Guid Id { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoReferencia TipoReferencia { get; set; }

        // FIX: Cambiado de TimeSpan a DateTime
        public DateTime Fecha { get; set; }

        // FIX: Le agregamos el '?' para evitar el warning de nulos
        public string? MedioPago { get; set; }

        // FIX: El dinero SIEMPRE se maneja con 'decimal' en C#
        public decimal MontoOriginal { get; set; }
        public decimal MontoFinal { get; set; }

        public EstadoCobro Estado { get; set; }
        public Recibo? Recibo { get; set; }
    }

    public enum EstadoCobro
    {
        Pendiente = 1,
        Confirmada = 2, // Lo usaremos cuando el cobro esté "Pagado"
        Cancelada = 3
    }

    public enum TipoReferencia
    {
        Reserva = 1,
        Inscripcion = 2
    }
}