using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryReserva
    {
        Task<Reserva> ObtenerPorIdAsync(Guid id);

        Task<IList<Reserva>> ObtenerTodosAsync();
    }
}