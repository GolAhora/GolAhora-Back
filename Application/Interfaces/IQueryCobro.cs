using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryCobro
    {
        Task<Cobro> ObtenerPorIdAsync(Guid id);

        Task<IList<Cobro>> ObtenerTodosAsync();

        Task<IList<Cobro>> ObtenerPorFechaAsync(DateTime fecha);

        Task<IList<Cobro>> ObtenerPorReservaAsync(Guid idReserva);

        Task<IList<Cobro>> ObtenerPorUsuarioAsync(Guid idUsuario);
    }
}