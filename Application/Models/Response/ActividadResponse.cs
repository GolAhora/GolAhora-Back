using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class ActividadResponse
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int CupoMaximo { get; set; } // Agregado por regla de negocio
        public Guid CanchaId { get; set; }

    }
}
