using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Competencia
    {
        public Guid Id { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Reglamento { get; set; }
        public List<Inscripcion> Inscripciones { get; set; }
        public  EstadoCompetencia Estado { get; set; }
    }
}

public enum EstadoCompetencia
{
    EnCurso = 1,
    Finalizada = 2
}