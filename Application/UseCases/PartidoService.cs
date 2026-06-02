using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class PartidoService : IPartidoService
    {
        public Task<PartidoResponse> ConsultarPartido(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PartidoResponse>> ConsultarPartidosPorCompetencia(Guid competenciaId)
        {
            throw new NotImplementedException();
        }

        public Task<PartidoResponse> EliminarPartido(Guid id)
        {
            throw new NotImplementedException();
  
        }

        public Task<PartidoResponse> ModificarResultado(Guid id, PartidoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PartidoResponse> RegistrarResultado(PartidoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

                Precio = create.Precio,
                Ingredientes = create.Ingredientes,
                Preparacion = create.Preparacion,
                Imagen = create.Imagen,

                Tipo = new TipoMercaderiaResponse()
                {
                    Id = create.TipoMercaderia.TipoMercaderiaId,
                    Descripcion = create.TipoMercaderia.Descripcion
                }
            };

            return response;
        }

        public Task<PartidoResponse> ModificarResultado(Guid id, PartidoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PartidoResponse> RegistrarResultado(PartidoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
