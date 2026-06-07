using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Enums;

namespace Application.Models.Request
{
    public class InscripcionRequest
    {
        public Guid UsuarioId { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoInscripcion TipoInscripcion { get; set; }
    }
}
