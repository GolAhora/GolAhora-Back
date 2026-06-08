using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : Persona
    {
        public string ClerkId { get; set; } 
        public DateTime FechaRegistro { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Inscripcion> Inscripciones { get; set; }

    }
}
