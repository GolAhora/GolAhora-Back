
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de coordinar los casos de uso de Mantenimiento
    public class ServiceMantenimiento : IServiceMantenimiento
    {
        // Referencia a Query (Lectura) y Command (Escritura)
        private readonly IQueryMantenimiento _query;
        private readonly ICommandMantenimiento _command;

        public ServiceMantenimiento(IQueryMantenimiento query, ICommandMantenimiento command)
        {
            _query = query;
            _command = command;
        }

        public async Task<MantenimientoResponse> ConsultarMantenimiento(Guid id)
        {
            // Usamos el Query para leer
            var mantenimiento = await _query.ObtenerPorIdAsync(id);

            if (mantenimiento == null)
            {
                throw new Exception("Mantenimiento no encontrado.");
            }

            return Mapear(mantenimiento);
        }

        public async Task<IList<MantenimientoResponse>> ConsultarMantenimientos()
        {
            // Usamos el Query para leer la lista completa
            var mantenimientos = await _query.ObtenerTodosAsync();

            return mantenimientos.Select(Mapear).ToList();
        }

        public async Task<MantenimientoResponse> RegistrarMantenimiento(MantenimientoRequest request)
        {
            // 1. REGLA DE NEGOCIO
            string estadoInicial = "Programado";

            // 2. EL CREATE (Entidad)
            var nuevoMantenimiento = new Mantenimiento
            {
                CanchaId = request.CanchaId,
                Fecha = request.Fecha,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                Motivo = request.Motivo,
                Estado = estadoInicial
            };

            // 3. Usamos el Command para escribir en la base de datos
            await _command.AgregarAsync(nuevoMantenimiento);

            // 4. EL RESPONSE
            return Mapear(nuevoMantenimiento);
        }

        public async Task<MantenimientoResponse> ModificarMantenimiento(Guid id, MantenimientoRequest request)
        {
            // Leemos con Query
            var mantenimientoExistente = await _query.ObtenerPorIdAsync(id);

            if (mantenimientoExistente == null)
            {
                throw new Exception("El mantenimiento no existe en el sistema.");
            }

            // Pisamos los datos
            mantenimientoExistente.CanchaId = request.CanchaId;
            mantenimientoExistente.Fecha = request.Fecha;
            mantenimientoExistente.HoraInicio = request.HoraInicio;
            mantenimientoExistente.HoraFin = request.HoraFin;
            mantenimientoExistente.Motivo = request.Motivo;

            // Guardamos con Command
            await _command.ModificarAsync(mantenimientoExistente);

            return Mapear(mantenimientoExistente);
        }

        public async Task<MantenimientoResponse> EliminarMantenimiento(Guid id)
        {
            // Leemos con Query
            var mantenimiento = await _query.ObtenerPorIdAsync(id);

            if (mantenimiento == null)
            {
                throw new Exception("El mantenimiento que intenta eliminar no existe.");
            }

            // Eliminamos con Command
            await _command.EliminarAsync(id);

            return Mapear(mantenimiento);
        }

        // Método extra específico de la interfaz de Mantenimiento
        public async Task<MantenimientoResponse> AgregarCanchaAMantenimiento(Guid idMantenimiento, Guid idCancha)
        {
            // Leemos con Query
            var mantenimiento = await _query.ObtenerPorIdAsync(idMantenimiento);

            if (mantenimiento == null)
            {
                throw new Exception("Mantenimiento no encontrado.");
            }

            // Actualizamos solo la cancha
            mantenimiento.CanchaId = idCancha;

            // Guardamos con Command
            await _command.ModificarAsync(mantenimiento);

            return Mapear(mantenimiento);
        }

        // --- MÉTODO PRIVADO DE MAPEO ---
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