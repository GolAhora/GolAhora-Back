using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Inscripcion
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        // Este ID guardará el Guid de la Actividad, Clase o Entrenamiento
        public Guid ReferenciaId { get; set; }

        // ¡AGREGAMOS ESTO! La propiedad de navegación para usar .Include()
        public Actividad? Actividad { get; set; }

        public TipoInscripcion TipoInscripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Usuario? Usuario { get; set; }
        public List<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}