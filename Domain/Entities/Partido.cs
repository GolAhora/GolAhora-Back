using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Partido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public String EquipoLocal { get; set; }
        public String EquipoVisitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public String Resultado { get; set; }
    }
}
