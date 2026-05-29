using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Actividad
    {
        public Guid Id { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int CupoMaximo { get; set; }
        public Guid CanchaId { get; set; }

        public Cancha Cancha { get; set; } 


    }
}
