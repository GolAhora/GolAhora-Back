using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryPartido
    {
        Task<Partido> ObtenerPorIdAsync(Guid id);

        Task<IList<Partido>> ObtenerTodosAsync();
    }
}