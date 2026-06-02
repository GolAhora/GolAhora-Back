using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandCobro
    {
        Task AgregarAsync(Cobro cobro);

        Task ModificarAsync(Cobro cobro);

        Task EliminarAsync(Guid id);
    }
}