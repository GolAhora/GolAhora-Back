using System;

namespace Domain.Entities
{
    public class Reserva
    {
        // FIX 1: Cambiamos 'int' por 'Guid' para estandarizar todo el sistema
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public EstadoReserva Estado { get; set; }

        public Guid CanchaId { get; set; }
        public Guid UsuarioId { get; set; }

        // FIX 2: Le agregamos '?' para que el compilador no llore por nulos
        public Usuario? Usuario { get; set; }
        public Cancha? Cancha { get; set; }
    }

    public enum EstadoReserva
    {
        Pendiente = 1,
        Confirmada = 2,
        Cancelada = 3
    }
}