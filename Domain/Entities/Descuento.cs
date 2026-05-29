using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Descuento
    {
        public Guid Id { get; set; }
        public String Nombre { get; set; }  
        public double Porcentaje { get; set; }  
        public Boolean EstadoActivo { get; set; }
    }
}
