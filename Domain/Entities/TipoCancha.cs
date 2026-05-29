using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoCancha
    {
        public Guid Id { get; set; }

        public String Nombre { get; set; }
        public int Superficie { get; set; }
        public int Capacidad { get; set; }  
        public double DuracionMax { get; set; }
        public double PrecioBaseHora { get; set; }

        public List<Cancha> Canchas { get; set; }
    }
}
