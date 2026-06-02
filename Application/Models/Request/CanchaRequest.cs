using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CanchaRequest
    {
        public int Numero { get; set; } // ¡MODIFICADO!
        public Guid TipoCanchaId { get; set; } // ¡MODIFICADO!

    }
}
