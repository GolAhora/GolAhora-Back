using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandCompetencia
    {
        Task AgregarAsync(Competencia competencia);

        Task ModificarAsync(Competencia competencia);

        Task EliminarAsync(Guid id);
    }
}