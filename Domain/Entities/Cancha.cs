using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cancha
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public EstadoCancha Estado { get; set; }
        public Guid TipoCanchaId { get; set; }

        public TipoCancha TipoCancha { get; set; }  
        public List<Actividad> Actividades { get; set; }
        public List<Mantenimiento> Mantenimientos { get; set; }
        public List<Reserva> Reservas { get; set; }

    }
}

 public enum EstadoCancha
{
    Disponible,
    Ocupada,
    Mantenimiento
}
