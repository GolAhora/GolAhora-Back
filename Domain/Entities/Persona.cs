using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {
        public Guid Id { get; set; }

        // --- OBLIGATORIOS ---
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // --- OPCIONALES (Nuleables) ---
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}