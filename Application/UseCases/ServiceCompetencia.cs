using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar todas las operaciones relacionadas con Competencias
    public class ServiceCompetencia : IServiceCompetencia
    {
        // Referencias a Query y Command
        private readonly IQueryCompetencia _query;
        private readonly ICommandCompetencia _command;

        // Constructor
        public ServiceCompetencia(
            IQueryCompetencia query,
            ICommandCompetencia command)
        {
            _query = query;
            _command = command;
        }

        // Busca una competencia por su Id
        public async Task<CompetenciaResponse> ConsultarCompetencia(Guid id)
        {
            Competencia competencia =
                await _query.ObtenerPorIdAsync(id);

            if (competencia == null)
            {
                throw new Exception(
                    "La competencia no existe.");
            }

            return Mapear(competencia);
        }

        // Devuelve todas las competencias registradas
        public async Task<IList<CompetenciaResponse>> ConsultarCompetencias()
        {
            IList<Competencia> competencias =
                await _query.ObtenerTodosAsync();

            List<CompetenciaResponse> listaCompetencias =
                new List<CompetenciaResponse>();

            foreach (Competencia competencia in competencias)
            {
                listaCompetencias.Add(
                    Mapear(competencia));
            }

            return listaCompetencias;
        }

        // Registra una nueva competencia
        public async Task<CompetenciaResponse> RegistrarCompetencia(
            CompetenciaRequest request)
        {
            // Validamos que las fechas sean correctas
            if (request.FechaInicio > request.FechaFin)
            {
                throw new Exception(
                    "La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            // Creamos una nueva competencia
            Competencia nuevaCompetencia =
                new Competencia();

            nuevaCompetencia.Nombre =
                request.Nombre;

            nuevaCompetencia.FechaInicio =
                request.FechaInicio;

            nuevaCompetencia.FechaFin =
                request.FechaFin;

            nuevaCompetencia.ReglamentoOficial =
                request.ReglamentoOficial;

            nuevaCompetencia.ReglamentoInterno =
                request.ReglamentoInterno;

            // Guardamos la competencia
            await _command.AgregarAsync(
                nuevaCompetencia);

            return Mapear(nuevaCompetencia);
        }

        // Modifica una competencia existente
        public async Task<CompetenciaResponse> ModificarCompetencia(
            Guid id,
            CompetenciaRequest request)
        {
            Competencia competencia =
                await _query.ObtenerPorIdAsync(id);

            if (competencia == null)
            {
                throw new Exception(
                    "Competencia no encontrada.");
            }

            // Actualizamos los datos
            competencia.Nombre =
                request.Nombre;

            competencia.FechaInicio =
                request.FechaInicio;

            competencia.FechaFin =
                request.FechaFin;

            competencia.ReglamentoOficial =
                request.ReglamentoOficial;

            competencia.ReglamentoInterno =
                request.ReglamentoInterno;

            // Guardamos los cambios
            await _command.ModificarAsync(
                competencia);

            return Mapear(competencia);
        }

        // Elimina una competencia
        public async Task<CompetenciaResponse> EliminarCompetencia(
            Guid id)
        {
            Competencia competencia =
                await _query.ObtenerPorIdAsync(id);

            if (competencia == null)
            {
                throw new Exception(
                    "La competencia que intenta eliminar no existe.");
            }

            await _command.EliminarAsync(id);

            return Mapear(competencia);
        }

        // Organizar una competencia termina haciendo lo mismo que registrar
        public async Task<CompetenciaResponse> OrganizarCompetencia(
            CompetenciaRequest request)
        {
            return await RegistrarCompetencia(request);
        }


        // MÉTODOS QUE DEPENDEN DE OTRAS ENTIDADES


        // Agregar usuario a competencia
        public Task<CompetenciaResponse> AgregarUsuarioACompetencia(
            Guid idCompetencia,
            Guid idUsuario)
        {
            throw new NotImplementedException(
                "Falta implementar la relación entre Competencias y Usuarios.");
        }

        // Eliminar usuario de competencia
        public Task<CompetenciaResponse> EliminarUsuarioDeCompetencia(
            Guid idCompetencia,
            Guid idUsuario)
        {
            throw new NotImplementedException(
                "Falta implementar la relación entre Competencias y Usuarios.");
        }

        // Agregar actividad a competencia
        public Task<CompetenciaResponse> AgregarActividadACompetencia(
            Guid idCompetencia,
            Guid idActividad)
        {
            throw new NotImplementedException(
                "Falta implementar la relación entre Competencias y Actividades.");
        }

        // Eliminar actividad de competencia
        public Task<CompetenciaResponse> EliminarActividadDeCompetencia(
            Guid idCompetencia,
            Guid idActividad)
        {
            throw new NotImplementedException(
                "Falta implementar la relación entre Competencias y Actividades.");
        }

        // Este método debería recibir parámetros
        public Task<IList<CompetenciaResponse>> IncribirUsario()
        {
            throw new NotImplementedException(
                "Revisar interfaz y agregar parámetros.");
        }

        // Consultar usuarios inscriptos
        public Task<CompetenciaResponse> ConsultarInscriptos()
        {
            throw new NotImplementedException();
        }

        // Generar fixture automático
        public Task<CompetenciaResponse> GenerarFixture()
        {
            throw new NotImplementedException(
                "Falta implementar la lógica de generación de fixture.");
        }

        // Consultar fixture
        public Task<CompetenciaResponse> ConsultarFixture()
        {
            throw new NotImplementedException();
        }



        // Convierte una entidad Competencia
        // en un objeto CompetenciaResponse
        private CompetenciaResponse Mapear(
            Competencia competencia)
        {
            CompetenciaResponse respuesta =
                new CompetenciaResponse();

            respuesta.Id = competencia.Id;
            respuesta.Nombre = competencia.Nombre;
            respuesta.FechaInicio = competencia.FechaInicio;
            respuesta.FechaFin = competencia.FechaFin;
            respuesta.ReglamentoOficial =
                competencia.ReglamentoOficial;
            respuesta.ReglamentoInterno =
                competencia.ReglamentoInterno;

            return respuesta;
        }
    }
}