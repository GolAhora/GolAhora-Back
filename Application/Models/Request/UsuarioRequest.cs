using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UsuarioRequest
    {
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; } // OBLIGATORIO según requerimiento
        public int? Edad { get; set; }
        public string? Password { get; set; }

    }
}
