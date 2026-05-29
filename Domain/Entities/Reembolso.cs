using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reembolso
    {
        public int Id { get; set; }
        public float Monto { get; set; }
        public DateTime Fecha { get; set; }
        public String Motivo { get; set; }
        public Guid CobroId { get; set; }

    }

}
