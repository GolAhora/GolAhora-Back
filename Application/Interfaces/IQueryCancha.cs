using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryCancha
    {
        Task<Cancha> ObtenerPorIdAsync(Guid id);

        Task<IList<Cancha>> ObtenerTodosAsync();
    }
}