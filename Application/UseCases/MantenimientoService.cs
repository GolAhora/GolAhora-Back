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
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de ser el "cerebro" de los Mantenimientos de las canchas
    public class MantenimientoService : IMantenimientoService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryMantenimiento _query;
        private readonly ICommandMantenimiento _command;

        // Constructor: C# inyecta estas herramientas automáticamente
        public MantenimientoService(IQueryMantenimiento query, ICommandMantenimiento command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<MantenimientoResponse> ConsultarMantenimiento(Guid id)
        {
            var mantenimiento = await _query.ObtenerPorIdAsync(id);

            if (mantenimiento == null) throw new Exception("Mantenimiento no encontrado.");

            return Mapear(mantenimiento);
        }

        public async Task<IList<MantenimientoResponse>> ConsultarMantenimientos()
    {
            var mantenimientos = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista a Response en un solo paso
            return mantenimientos.Select(Mapear).ToList();
        }

        public async Task<MantenimientoResponse> RegistrarMantenimiento(MantenimientoRequest request)
        {
            // Regla de Negocio: Validamos la lógica del tiempo
            if (request.HoraInicio >= request.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser anterior a la hora de fin.");
        }

            // Armamos el ticket de mantenimiento completo en un solo bloque
            var nuevoMantenimiento = new Mantenimiento
        {
                CanchaId = request.CanchaId,
                Fecha = request.Fecha,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                Motivo = request.Motivo,
                // Todo mantenimiento nace programado para el futuro
                Estado = "Programado"
            };

            await _command.AgregarAsync(nuevoMantenimiento);

            return Mapear(nuevoMantenimiento);
        }

        public async Task<MantenimientoResponse> ModificarMantenimiento(Guid id, MantenimientoRequest request)
        {
            var mantenimientoExistente = await _query.ObtenerPorIdAsync(id);

            if (mantenimientoExistente == null) throw new Exception("El mantenimiento no existe en el sistema.");

            if (request.HoraInicio >= request.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser anterior a la hora de fin.");
            }

            // Pisamos los datos permitidos
            mantenimientoExistente.CanchaId = request.CanchaId;
            mantenimientoExistente.Fecha = request.Fecha;
            mantenimientoExistente.HoraInicio = request.HoraInicio;
            mantenimientoExistente.HoraFin = request.HoraFin;
            mantenimientoExistente.Motivo = request.Motivo;

            await _command.ModificarAsync(mantenimientoExistente);

            return Mapear(mantenimientoExistente);
        }

        public async Task<MantenimientoResponse> EliminarMantenimiento(Guid id)
        {
            var mantenimiento = await _query.ObtenerPorIdAsync(id);

            if (mantenimiento == null) throw new Exception("El mantenimiento que intenta eliminar no existe.");

            await _command.EliminarAsync(id);

            return Mapear(mantenimiento);
        }


        // --- 2. MÉTODOS ESPECÍFICOS ---

        // Nota: Si el mantenimiento ya se registró con una CanchaId (ver RegistrarMantenimiento), 
        // este método en realidad hace una "Modificación" de la cancha asignada.
        public async Task<MantenimientoResponse> AgregarCanchaAMantenimiento(Guid idMantenimiento, Guid idCancha)
        {
            var mantenimiento = await _query.ObtenerPorIdAsync(idMantenimiento);

            if (mantenimiento == null) throw new Exception("Mantenimiento no encontrado.");

            // Actualizamos únicamente a qué cancha pertenece
            mantenimiento.CanchaId = idCancha;

            await _command.ModificarAsync(mantenimiento);

            return Mapear(mantenimiento);
        }


        // --- 3. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la entidad en un objeto de respuesta seguro para la pantalla
        private MantenimientoResponse Mapear(Mantenimiento mantenimiento)
        {
            return new MantenimientoResponse
            {
                Id = mantenimiento.Id,
                CanchaId = mantenimiento.CanchaId,
                Fecha = mantenimiento.Fecha,
                HoraInicio = mantenimiento.HoraInicio,
                HoraFin = mantenimiento.HoraFin,
                Motivo = mantenimiento.Motivo,
                Estado = mantenimiento.Estado
            };
        }
    }
}
