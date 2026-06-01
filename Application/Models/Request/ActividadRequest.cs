using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ActividadRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public Guid? CanchaId { get; set; }
    }
}
