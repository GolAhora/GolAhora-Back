using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mantenimiento
    {
        public Guid Id { get; set; }
        public Guid CanchaId { get; set; }  
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }  
        public String Motivo { get; set; }      
        public Boolean Estado { get; set; }



        public Cancha Cancha { get; set; }  
    }
}
