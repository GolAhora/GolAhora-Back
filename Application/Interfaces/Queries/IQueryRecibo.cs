using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IQueryRecibo
    {
        Task<Recibo> ObtenerPorIdAsync(Guid id);

        Task<IList<Recibo>> ObtenerTodosAsync();

        Task<IList<Recibo>> ObtenerPorUsuarioAsync(Guid idUsuario);
    }
}