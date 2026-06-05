using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de ser el "cerebro" de las Actividades
    public class ActividadService : IActividadService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryActividad _query;
        private readonly ICommandActividad _command;

        // Constructor: C# nos inyecta las herramientas al arrancar
        public ActividadService(IQueryActividad query, ICommandActividad command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<ActividadResponse> ConsultarActividad(Guid id)
        {
            // Usamos 'var' para no repetir código. Traemos la actividad.
            var actividad = await _query.ObtenerPorIdAsync(id);

            // Si no existe, frenamos todo
            if (actividad == null)
            {
                throw new Exception("La actividad solicitada no existe.");
            }

            // Traducimos a Response y enviamos
            return Mapear(actividad);
        }

        public async Task<IList<ActividadResponse>> ConsultarActividades()
        {
            var actividades = await _query.ObtenerTodosAsync();

            // Usamos LINQ para traducir toda la lista en una sola línea elegante
            return actividades.Select(Mapear).ToList();
        }

        public async Task<ActividadResponse> ProgramarActividad(ActividadRequest request)
        {
            // Regla de negocio: El cupo no puede ser cero o negativo
            if (request.CupoMaximo <= 0)
            {
                throw new Exception("El cupo máximo debe ser mayor a cero.");
            }

            // Armamos la actividad completa en un solo bloque (Object Initializer)
            var nuevaActividad = new Actividad
            {
                Nombre = request.Nombre,
                Fecha = request.Fecha,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                CupoMaximo = request.CupoMaximo,
                CanchaId = request.CanchaId
            };

            // Guardamos en la base de datos
            await _command.AgregarAsync(nuevaActividad);

            return Mapear(nuevaActividad);
        }

        public async Task<ActividadResponse> ModificarActividad(Guid id, ActividadRequest request)
        {
            var actividadExistente = await _query.ObtenerPorIdAsync(id);

            if (actividadExistente == null) throw new Exception("La actividad que intenta modificar no existe.");

            // Pisamos los datos viejos con los nuevos
            actividadExistente.Nombre = request.Nombre;
            actividadExistente.Fecha = request.Fecha;
            actividadExistente.HoraInicio = request.HoraInicio;
            actividadExistente.HoraFin = request.HoraFin;
            actividadExistente.CupoMaximo = request.CupoMaximo;
            actividadExistente.CanchaId = request.CanchaId;

            // Guardamos los cambios
            await _command.ModificarAsync(actividadExistente);

            return Mapear(actividadExistente);
        }

        public async Task<ActividadResponse> EliminarActividad(Guid id)
        {
            var actividad = await _query.ObtenerPorIdAsync(id);

            if (actividad == null) throw new Exception("La actividad que intenta eliminar no existe.");

            // Eliminamos usando el ID
            await _command.EliminarAsync(id);

            return Mapear(actividad);
        }

        // Programar y Registrar hacen lo mismo, reciclamos código
        public async Task<ActividadResponse> Registrar(ActividadRequest request)
        {
            return await ProgramarActividad(request);
        }


        // --- 2. MÉTODOS DE REGLAS DE NEGOCIO ---

        public async Task<ActividadResponse> ConsultarActividadPorCompetencia(Guid idCompetencia)
        {
            var actividades = await _query.ObtenerPorCompetenciaAsync(idCompetencia);

            // FirstOrDefault trae el primero de la lista, o 'null' si la lista está vacía
            var primeraActividad = actividades.FirstOrDefault();

            if (primeraActividad == null)
            {
                throw new Exception("No hay actividades para esta competencia.");
            }

            return Mapear(primeraActividad);
        }

        // Nota: Agregué el parámetro 'idActividad' porque si no el sistema no sabe de dónde borrar al usuario
        public async Task<ActividadResponse> CancelarInscripcionPorUsuario(Guid idActividad, Guid idUsuario)
        {
            var actividad = await _query.ObtenerPorIdAsync(idActividad);
            if (actividad == null) throw new Exception("Actividad no encontrada.");

            // Buscamos si el usuario está inscripto en esta actividad
            var inscripcion = actividad.Inscripciones.FirstOrDefault(i => i.UsuarioId == idUsuario);

            if (inscripcion != null)
            {
                // Lo borramos de la lista y guardamos
                actividad.Inscripciones.Remove(inscripcion);
                await _command.ModificarAsync(actividad);
            }

            return Mapear(actividad);
        }

        public async Task<ActividadResponse> ValidarCupoPorActividad(Guid idActividad)
        {
            var actividad = await _query.ObtenerPorIdAsync(idActividad);

            if (actividad == null) throw new Exception("Actividad no encontrada.");

            // Verificamos si la cantidad de inscriptos ya llegó al máximo permitido
            if (actividad.Inscripciones.Count >= actividad.CupoMaximo)
            {
                throw new Exception("El cupo de esta actividad ya está lleno.");
            }

            // Si hay lugar, devolvemos la actividad sin errores
            return Mapear(actividad);
        }


        // --- 3. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la Entidad de la base de datos en un formato seguro para la web
        private ActividadResponse Mapear(Actividad actividad)
        {
            return new ActividadResponse
            {
                Id = actividad.Id,
                Nombre = actividad.Nombre,
                Fecha = actividad.Fecha,
                HoraInicio = actividad.HoraInicio,
                HoraFin = actividad.HoraFin,
                CupoMaximo = actividad.CupoMaximo,
                CanchaId = actividad.CanchaId
            };
        }

        public Task<ActividadResponse> ModificarActividad(ActividadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadResponse> CancelarInscripcionPorUsuario(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}