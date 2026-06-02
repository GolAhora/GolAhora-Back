using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IQueryCancha
    {
        public Task<IList<Cancha>> ConsultarCanchas(); 
        public Task<Boolean> ConsultarDisponibildiad(Guid id, bool disponible);
        public Task<Cancha> ConsultarCanchaPorId(Guid id);
        public Task<Cancha> ConsultarMantenimientoDeCancha(Guid id);
    }
}
