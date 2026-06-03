using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Actividad
    {
        public Guid Id { get; set; }

        public string? Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public int CupoMaximo { get; set; }

        public Guid CanchaId { get; set; }

        public Cancha? Cancha { get; set; }

        public List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}