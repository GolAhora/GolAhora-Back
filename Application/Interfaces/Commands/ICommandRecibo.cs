using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandRecibo
    {
        Task AgregarAsync(Recibo recibo);

        Task ModificarAsync(Recibo recibo);

        Task EliminarAsync(Guid id);
    }
}