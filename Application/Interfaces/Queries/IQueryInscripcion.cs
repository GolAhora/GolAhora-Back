using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryInscripcion
    {
         Task<Inscripcion> ConsultarInscripcion(Guid id);
    }
}