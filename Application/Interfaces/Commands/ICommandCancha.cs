using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface ICommandCancha
    {
        Task<Cancha> CrearCancha(Cancha cancha);

        Task<Cancha?> ModificarCancha(Guid id, Cancha cancha);

        Task<Cancha?> EliminarCancha(Guid id);
    }
}