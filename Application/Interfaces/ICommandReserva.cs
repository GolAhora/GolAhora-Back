using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandReserva
    {
        Task AgregarAsync(Reserva reserva);

        Task ModificarAsync(Reserva reserva);

        Task EliminarAsync(Guid id);
    }
}