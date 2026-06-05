using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryCancha
    {
        Task<Cancha?> ConsultarCanchaPorId(Guid id);
        Task<IList<Cancha>> ConsultarCanchas();
        Task<bool> ConsultarDisponibildiad(Guid id);
    }
}