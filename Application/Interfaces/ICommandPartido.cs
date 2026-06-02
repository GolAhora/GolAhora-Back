using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandPartido
    {
        Task AgregarAsync(Partido partido);

        Task ModificarAsync(Partido partido);

        Task EliminarAsync(Guid id);
    }
}