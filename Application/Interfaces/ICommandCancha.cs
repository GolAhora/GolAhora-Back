
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommandCancha
    {
       public Task<Cancha> CrearCancha(Cancha cancha);
       public Task<Cancha> ActualizarCancha(Guid id, Cancha cancha);
       public Task<Cancha> EliminarCancha(Guid id);
       //Task<> ProgramarMantenimientoACancha(Guid idCancha, Guid idMantenimiento);
       //Task<> CancelarMantenimientoACancha(Guid idCancha, Guid idMantenimiento);

    }
}
