using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de ser el "cerebro" de las Canchas
    public class ServiceCancha : ICanchaService
    {
        // Herramientas para leer (_query) y escribir (_command)
        private readonly IQueryCancha _query;
        private readonly ICommandCancha _command;

        // Constructor: C# nos inyecta las herramientas al arrancar
        public ServiceCancha(IQueryCancha query, ICommandCancha command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<CanchaResponse> ConsultarCanchaPorId(Guid id)
        {
            var cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null) throw new Exception("La cancha solicitada no existe.");

            return Mapear(cancha);
        }

        public async Task<IList<CanchaResponse>> ConsultarCanchas()
        {
            var canchas = await _query.ObtenerTodosAsync();

            // Magia de LINQ: Traducimos toda la lista a Response en una sola línea
            return canchas.Select(Mapear).ToList();
        }

        public async Task<CanchaResponse> CrearCancha(CanchaRequest request)
        {
            // Armamos la cancha completa en un solo bloque ordenado
            var nuevaCancha = new Cancha
            {
                Numero = request.Numero,
                TipoCanchaId = request.TipoCanchaId,
                // Regla de negocio: Toda cancha nueva nace disponible
                Estado = EstadoCancha.Disponible
            };

            await _command.AgregarAsync(nuevaCancha);

            return Mapear(nuevaCancha);
        }

        public async Task<CanchaResponse> ActualizarCancha(Guid id, CanchaRequest request)
        {
            var canchaExistente = await _query.ObtenerPorIdAsync(id);

            if (canchaExistente == null) throw new Exception("La cancha que intenta modificar no existe.");

            // Pisamos los datos
            canchaExistente.Numero = request.Numero;
            canchaExistente.TipoCanchaId = request.TipoCanchaId;

            await _command.ModificarAsync(canchaExistente);

            return Mapear(canchaExistente);
        }

        public async Task<CanchaResponse> EliminarCancha(Guid id)
        {
            var cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null) throw new Exception("La cancha que intenta eliminar no existe.");

            await _command.EliminarAsync(id);

            return Mapear(cancha);
        }


        // --- 2. MÉTODOS DE ESTADO Y DISPONIBILIDAD ---

        // Nota: Mantenemos el error de tipeo en el nombre (Disponibildiad) para no romper tu Interfaz
        public async Task<bool> ActualizarDisponibildiad(Guid id, bool disponible)
        {
            var cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null) return false;

            // Truco Senior (Operador Ternario): Si 'disponible' es true, asigna Disponible. Si es false, asigna Ocupada.
            cancha.Estado = disponible ? EstadoCancha.Disponible : EstadoCancha.Ocupada;

            await _command.ModificarAsync(cancha);

            return true;
        }

        public async Task<bool> ConsultarDisponibildiad(Guid id, bool disponible)
        {
            var cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null) throw new Exception("Cancha no encontrada.");

            // Devuelve 'true' si el estado actual es Disponible
            return cancha.Estado == EstadoCancha.Disponible;
        }


        // --- 3. MÉTODOS DE MANTENIMIENTO ---

        public async Task<CanchaResponse> ProgramarMantenimientoACancha(Guid idCancha, Guid idMantenimiento)
        {
            var cancha = await _query.ObtenerPorIdAsync(idCancha);

            if (cancha == null) throw new Exception("Cancha no encontrada.");

            // Cambiamos el estado de la cancha
            cancha.Estado = EstadoCancha.Mantenimiento;

            await _command.ModificarAsync(cancha);

            return Mapear(cancha);
        }

        public async Task<CanchaResponse> CancelarMantenimientoACancha(Guid idCancha, Guid idMantenimiento)
        {
            var cancha = await _query.ObtenerPorIdAsync(idCancha);

            if (cancha == null) throw new Exception("Cancha no encontrada.");

            // Devolvemos la cancha a su estado operativo
            cancha.Estado = EstadoCancha.Disponible;

            await _command.ModificarAsync(cancha);

            return Mapear(cancha);
        }


        // --- 4. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la Entidad de la base de datos en un objeto listo para la pantalla
        private CanchaResponse Mapear(Cancha cancha)
        {
            return new CanchaResponse
            {
                Id = cancha.Id,
                Numero = cancha.Numero,
                Estado = cancha.Estado.ToString(), // Pasamos el Enum a texto
                TipoCanchaNombre = cancha.TipoCanchaId.ToString() // Pasamos el Guid a texto
            };
        }

        public Task<CanchaResponse> ConsultarMantenimientoDeCancha(Guid idCancha)
        {
            throw new NotImplementedException();
        }
    }
}