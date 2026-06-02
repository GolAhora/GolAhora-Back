using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Competencia
    {
        public Guid Id { get; set; }

        // Le agregamos el '?' para apagar los warnings de Null
        public string? Nombre { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // ¡ACÁ ESTÁ LA MAGIA! Dividimos el reglamento para que encaje con tu Request
        public string? ReglamentoOficial { get; set; }
        public string? ReglamentoInterno { get; set; }

        // Inicializamos la caja vacía para evitar errores futuros
        public List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

        public EstadoCompetencia Estado { get; set; }
    }

    public enum EstadoCompetencia
    {
        EnCurso = 1,
        Finalizada = 2
    }
}