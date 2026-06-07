using Domain.Entities;

namespace Application.Interfaces.Queries
{
    public interface IQueryTipoCancha
    {
        Task<TipoCancha?> ConsultarTipoCanchaPorId(Guid id);
        Task<IList<TipoCancha>> ConsultarTiposCancha();
    }
}
