using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Entrenamiento : Actividad
    {
        public String Categoria { get; set; }
        public Guid EntrenadorId { get; set; }
        public Entrenador Entrenador { get; set; } = null;
    }
}
