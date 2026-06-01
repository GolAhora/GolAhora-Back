using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CanchaRequest
    {
        public int Numero { get; set; }
        // En lugar de Nombre y Ubicacion, le pasamos a qué Tipo de Cancha pertenece (F5, F11)
        public Guid TipoCanchaId { get; set; }
        // No pasamos "Disponible". El estado nace por defecto según la regla de negocio del Servicio.

    }
}
