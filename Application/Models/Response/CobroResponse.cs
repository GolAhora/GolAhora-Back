using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class CobroResponse
    {
        public Guid Id { get; set; }
        public decimal MontoOriginal { get; set; }
        public decimal MontoFinal { get; set; }
        public DateTime Fecha { get; set; }
        public string? Estado { get; set; }
        public string? MedioPago { get; set; }
        public Guid ReferenciaId { get; set; }
    }
}
