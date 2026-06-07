using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Response
{
    public class CanchaResponse
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public EstadoCancha Estado { get; set; } 
        public TipoCanchaResponse TipoCancha { get; set; }


    }
}
