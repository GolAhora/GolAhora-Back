using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public EstadoReserva Estado { get; set; }
        public Guid CanchaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Cancha Cancha { get; set; }

    }
}


public enum EstadoReserva
{
    Pendiente,
    Confirmada,
    Cancelada
}