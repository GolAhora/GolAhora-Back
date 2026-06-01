using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CompetenciaRequest
    {
        public int? IdCompetencia { get; set; }  
        public string? NombreCompetencia { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? ReglamentoOficial { get; set; }
        public List<UsuarioRequest>? ListaInscriptos { get; set; }
        public bool? EstadoCompetencia { get; set; }
    }
}
