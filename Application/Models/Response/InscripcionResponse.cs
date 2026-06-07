using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Response
{
    public class InscripcionResponse
    {
    
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ReferenciaId { get; set; }
        public TipoInscripcion TipoInscripcion { get; set; }
        public DateTime Fecha { get; set; }



    }
}
