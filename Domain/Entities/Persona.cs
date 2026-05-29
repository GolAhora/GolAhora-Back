using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {
        public Guid Id { get; set; }
        public String Nombre { get; set; }
        public int Edad { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
    }
}
