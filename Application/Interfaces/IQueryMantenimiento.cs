using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryMantenimiento
    {
        Task<Mantenimiento> ObtenerPorIdAsync(Guid id);

        Task<IList<Mantenimiento>> ObtenerTodosAsync();
    }
}