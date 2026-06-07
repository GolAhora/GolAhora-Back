using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface ICommandTipoCancha
    {
        Task<TipoCancha> CrearTipoCancha(TipoCancha tipoCancha);
        Task<TipoCancha?> ModificarTipoCancha(Guid id, TipoCancha tipoCancha);
        Task<TipoCancha?> EliminarTipoCancha(Guid id);
    }
}
