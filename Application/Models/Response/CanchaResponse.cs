using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class CanchaResponse
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; } // "Disponible", "Ocupada", "Mantenimiento"
        public string TipoCanchaNombre { get; set; }


    }
}
