using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryCompetencia
    {
        Task<Competencia> ObtenerPorIdAsync(Guid id);

        Task<IList<Competencia>> ObtenerTodosAsync();
    }
}