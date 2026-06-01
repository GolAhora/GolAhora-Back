using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UsuarioRequest
    {
        public String? Nombre { get; set; }
        public String? Direccion { get; set; }
        public String? Telefono { get; set; }
        public int? Edad { get; set; }
        public String? Password { get; set; }

    }
}
