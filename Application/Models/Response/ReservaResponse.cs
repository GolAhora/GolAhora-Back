using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Response
{
    public class ReservaResponse
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public Estado Estado { get; set; }
        public CanchaResponse? Cancha { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
