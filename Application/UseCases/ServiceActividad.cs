using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar las actividades
    public class ServiceActividad : IServiceActividad
    {
        // Referencias a Query y Command
        private readonly IQueryActividad _query;
        private readonly ICommandActividad _command;

        // Constructor
        public ServiceActividad(IQueryActividad query, ICommandActividad command)
        {
            _query = query;
            _command = command;
        }

        // Busca una actividad por su Id
        public async Task<ActividadResponse> ConsultarActividad(Guid id)
        {
            Actividad actividad = await _query.ObtenerPorIdAsync(id);

            if (actividad == null)
            {
                throw new Exception("La actividad solicitada no existe.");
            }

            return Mapear(actividad);
        }

        // Devuelve todas las actividades
        public async Task<IList<ActividadResponse>> ConsultarActividades()
        {
            IList<Actividad> actividades = await _query.ObtenerTodosAsync();

            List<ActividadResponse> listaActividades =
                new List<ActividadResponse>();

            foreach (Actividad actividad in actividades)
            {
                listaActividades.Add(Mapear(actividad));
            }

            return listaActividades;
        }

        // Crea una nueva actividad
        public async Task<ActividadResponse> ProgramarActividad(
            ActividadRequest request)
        {
            // Validación simple
            if (request.CupoMaximo <= 0)
            {
                throw new Exception(
                    "El cupo máximo debe ser mayor a cero.");
            }

            // Creo la actividad
            Actividad nuevaActividad = new Actividad();

            nuevaActividad.Nombre = request.Nombre;
            nuevaActividad.Fecha = request.Fecha;
            nuevaActividad.HoraInicio = request.HoraInicio;
            nuevaActividad.HoraFin = request.HoraFin;
            nuevaActividad.CupoMaximo = request.CupoMaximo;
            nuevaActividad.CanchaId = request.CanchaId;

            // Guardo la actividad
            await _command.AgregarAsync(nuevaActividad);

            return Mapear(nuevaActividad);
        }

        // Modifica una actividad existente
        public async Task<ActividadResponse> ModificarActividad(
            Guid id,
            ActividadRequest request)
        {
            Actividad actividadExistente =
                await _query.ObtenerPorIdAsync(id);

            if (actividadExistente == null)
            {
                throw new Exception(
                    "La actividad que intenta modificar no existe.");
            }

            actividadExistente.Nombre = request.Nombre;
            actividadExistente.Fecha = request.Fecha;
            actividadExistente.HoraInicio = request.HoraInicio;
            actividadExistente.HoraFin = request.HoraFin;
            actividadExistente.CupoMaximo = request.CupoMaximo;
            actividadExistente.CanchaId = request.CanchaId;

            await _command.ModificarAsync(actividadExistente);

            return Mapear(actividadExistente);
        }

        // Elimina una actividad
        public async Task<ActividadResponse> EliminarActividad(Guid id)
        {
            Actividad actividad =
                await _query.ObtenerPorIdAsync(id);

            if (actividad == null)
            {
                throw new Exception(
                    "La actividad que intenta eliminar no existe.");
            }

            await _command.EliminarAsync(id);

            return Mapear(actividad);
        }

        // Registrar y Programar hacen lo mismo
        public async Task<ActividadResponse> Registrar(
            ActividadRequest request)
        {
            return await ProgramarActividad(request);
        }

        // Consulta actividades de una competencia
        public async Task<ActividadResponse>
            ConsultarActividadPorCompetencia(Guid idCompetencia)
        {
            IList<Actividad> actividades =
                await _query.ObtenerPorCompetenciaAsync(idCompetencia);

            Actividad primeraActividad = null;

            foreach (Actividad actividad in actividades)
            {
                primeraActividad = actividad;
                break;
            }

            if (primeraActividad == null)
            {
                throw new Exception(
                    "No hay actividades para esta competencia.");
            }

            return Mapear(primeraActividad);
        }

        // Pendiente de implementar
        public Task<ActividadResponse>
            CancelarInscripcionPorUsuario(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        // Verifica si existe la actividad
        public async Task<ActividadResponse>
            ValidarCupoPorActividad(Guid idActividad)
        {
            Actividad actividad =
                await _query.ObtenerPorIdAsync(idActividad);

            if (actividad == null)
            {
                throw new Exception("Actividad no encontrada.");
            }

            return Mapear(actividad);
        }

        // Convierte Actividad en ActividadResponse
        private ActividadResponse Mapear(Actividad actividad)
        {
            ActividadResponse respuesta =
                new ActividadResponse();

            respuesta.Id = actividad.Id;
            respuesta.Nombre = actividad.Nombre;
            respuesta.Fecha = actividad.Fecha;
            respuesta.HoraInicio = actividad.HoraInicio;
            respuesta.HoraFin = actividad.HoraFin;
            respuesta.CupoMaximo = actividad.CupoMaximo;
            respuesta.CanchaId = actividad.CanchaId;

            return respuesta;
        }

        public Task<ActividadResponse> ModificarActividad(
            ActividadRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
