using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Partido
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public string EquipoLocal { get; set; } = string.Empty;

        public string EquipoVisitante { get; set; } = string.Empty;

        public int GolesLocal { get; set; }

        public int GolesVisitante { get; set; }

        public string Resultado { get; set; } = string.Empty;

        public Guid CompetenciaId { get; set; }
    }
}