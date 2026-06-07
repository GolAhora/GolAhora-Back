using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IInscripcionService
    {
       Task<InscripcionResponse> AgregarInscripcion(InscripcionRequest request);
       Task<InscripcionResponse> CancelarInscripcion(Guid id);
       Task<InscripcionResponse> ConsultarInscripcion(Guid id);
       Task<InscripcionResponse> ModificarInscripcion(Guid id, InscripcionRequest request);

    }
}
