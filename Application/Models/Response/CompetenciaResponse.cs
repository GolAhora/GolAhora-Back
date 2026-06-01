using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class CompetenciaResponse
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? ReglamentoOficial { get; set; }
        public string? ReglamentoInterno { get; set; }

    }
}
