
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Linq;
using System.Text;


namespace Application.UseCases
{

    public class InscripcionService : IInscripcionService
    {
          private readonly IQueryInscripcion _query;
        private readonly ICommandInscripcion _command;

        public InscripcionService(IQueryInscripcion query, ICommandInscripcion command)
        {
            _query = query;
            _command = command;
        }
     public async Task<InscripcionResponse> AgregarInscripcion(InscripcionRequest request)
        {
       
            var nuevaInscripcion = new Inscripcion
        {
                Id = Guid.NewGuid(), 
                UsuarioId = request.UsuarioId,
                ReferenciaId = request.ReferenciaId,
                TipoInscripcion = Domain.Enums.TipoInscripcion.Competencia,
                Fecha = DateTime.Now
            };

            await _command.AgregarInscripcion(nuevaInscripcion);

            return Mapear(nuevaInscripcion);
        }

        public async Task<InscripcionResponse> CancelarInscripcion(Guid id)
        {
             var inscripcion = await _query.ConsultarInscripcion(id);

             if (inscripcion == null) throw new Exception("Inscripcion no encontrada.");

                await _command.CancelarInscripcion(inscripcion.Id);

            return Mapear(inscripcion);
        }

        public async Task<InscripcionResponse> ConsultarInscripcion(Guid id)
        {
           var inscripcion = await _query.ConsultarInscripcion(id);

            if (inscripcion == null) throw new Exception("La inscripcion no existe.");

            return Mapear(inscripcion);
        }

        public async Task<InscripcionResponse> ModificarInscripcion(Guid id, InscripcionRequest request)
        {
              var inscripcion = await _query.ConsultarInscripcion(id);

            if (inscripcion == null) throw new Exception("La inscripcion que intenta modificar no existe.");

            // Pisamos los datos permitidos
            inscripcion.ReferenciaId = request.ReferenciaId;
            inscripcion.TipoInscripcion = request.TipoInscripcion;
            inscripcion.UsuarioId = request.UsuarioId;
            inscripcion.Fecha = DateTime.UtcNow;

            await _command.ModificarInscripcion(id, inscripcion);

            return Mapear(inscripcion);
        }

        private InscripcionResponse Mapear(Inscripcion inscripcion)
        {
            return new InscripcionResponse
        {
                Id = inscripcion.Id,
                ReferenciaId = inscripcion.ReferenciaId,
                TipoInscripcion = inscripcion.TipoInscripcion,
                Fecha = inscripcion.Fecha,
                UsuarioId = inscripcion.UsuarioId
           
            };
        }

   
    }
}
