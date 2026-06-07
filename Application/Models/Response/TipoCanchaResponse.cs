using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class TipoCanchaResponse
    {

        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public int Superficie { get; set; }
        public int Capacidad { get; set; }  
        public double DuracionMax { get; set; }
        public double PrecioBaseHora { get; set; }  



    }
}
