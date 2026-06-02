using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class PartidoResponse
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public string? EquipoLocal { get; set; }

        public string? EquipoVisitante { get; set; }

        public int GolesLocal { get; set; }

        public int GolesVisitante { get; set; }

        public string? Resultado { get; set; }

        public Guid CompetenciaId { get; set; }
    }
}