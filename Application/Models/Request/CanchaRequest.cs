using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CanchaRequest
    {
        public int? IdCancha { get; set; }
        public int? Numero { get; set; }
        public bool? Disponibilidad  { get; set; }
        public string? Estado { get; set; }
    }
}
