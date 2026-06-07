using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Request
{
    public class CanchaRequest
    {
        public int? Numero { get; set; }
        public Guid TipoCanchaId { get; set; } 
        public EstadoCancha? Estado { get; set; } 

    }
}
