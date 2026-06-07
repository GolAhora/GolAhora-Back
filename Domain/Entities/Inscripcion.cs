using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Inscripcion
    {
        // FIX 1: Lo pasamos a Guid para mantener el estándar de tu sistema
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoInscripcion TipoInscripcion { get; set; }

        // Esta es la propiedad correcta para la fecha
        public DateTime Fecha { get; set; }

        // FIX 2: Apagamos los warnings de nulos y preparamos la lista vacía
        public Usuario? Usuario { get; set; }
        public List<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }


}