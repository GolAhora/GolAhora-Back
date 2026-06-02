using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryActividad
    {
        Task<Actividad> ObtenerPorIdAsync(Guid id);

        Task<IList<Actividad>> ObtenerTodosAsync();

        Task<IList<Actividad>> ObtenerPorCompetenciaAsync(Guid idCompetencia);
    }
}