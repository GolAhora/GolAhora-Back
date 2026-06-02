using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class PartidoRequest
    {
        public DateTime Fecha { get; set; }
        public string? EquipoLocal { get; set; }
        public string? EquipoVisitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public Guid CompetenciaId { get; set; } // ¡NUEVO! Vital para sumar puntos
    }
}