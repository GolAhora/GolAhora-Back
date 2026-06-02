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
    // Servicio encargado de ser el "cerebro" de las Reservas
    public class ServiceReserva : IReservaService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryReserva _query;
        private readonly ICommandReserva _command;

        // Constructor: C# inyecta estas herramientas automáticamente
        public ServiceReserva(IQueryReserva query, ICommandReserva command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<ReservaResponse> ConsultarReserva(Guid id)
        {
            var reserva = await _query.ObtenerPorIdAsync(id);

            if (reserva == null) throw new Exception("La reserva solicitada no existe.");

            return Mapear(reserva);
        }

        public async Task<IList<ReservaResponse>> ConsultarReservas()
        {
            var reservas = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista a Response en un solo paso
            return reservas.Select(Mapear).ToList();
        }

        public async Task<ReservaResponse> CrearReserva(ReservaRequest request)
        {
            // Regla de negocio: Validamos la coherencia del tiempo
            if (request.HoraInicio >= request.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser anterior a la hora de fin.");
            }

            // Armamos la reserva completa en un solo bloque
            var nuevaReserva = new Reserva
            {
                UsuarioId = request.UsuarioId,
                CanchaId = request.CanchaId,
                Fecha = request.Fecha,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                // Al crearla, asumimos que está confirmada
                Estado = EstadoReserva.Confirmada
            };

            await _command.AgregarAsync(nuevaReserva);

            return Mapear(nuevaReserva);
        }

        public async Task<ReservaResponse> ModificarReserva(Guid id, ReservaRequest request)
        {
            var reservaExistente = await _query.ObtenerPorIdAsync(id);

            if (reservaExistente == null) throw new Exception("La reserva que intenta modificar no existe.");

            if (request.HoraInicio >= request.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser anterior a la hora de fin.");
            }

            // Pisamos los datos permitidos
            reservaExistente.CanchaId = request.CanchaId;
            reservaExistente.UsuarioId = request.UsuarioId;
            reservaExistente.Fecha = request.Fecha;
            reservaExistente.HoraInicio = request.HoraInicio;
            reservaExistente.HoraFin = request.HoraFin;

            await _command.ModificarAsync(reservaExistente);

            return Mapear(reservaExistente);
        }

        // Regla de Negocio: En vez de borrarla de la base de datos (Eliminar), le cambiamos el estado
        public async Task<ReservaResponse> CancelarReserva(Guid id)
        {
            var reserva = await _query.ObtenerPorIdAsync(id);

            if (reserva == null) throw new Exception("La reserva que intenta cancelar no existe.");

            reserva.Estado = EstadoReserva.Cancelada;

            await _command.ModificarAsync(reserva);

            return Mapear(reserva);
        }


        // --- 2. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la entidad de la BD en un objeto de respuesta seguro para la pantalla
        private ReservaResponse Mapear(Reserva reserva)
        {
            return new ReservaResponse
            {
                Id = reserva.Id,
                UsuarioId = reserva.UsuarioId,
                CanchaId = reserva.CanchaId,
                Fecha = reserva.Fecha,
                HoraInicio = reserva.HoraInicio,
                HoraFin = reserva.HoraFin,
                Estado = reserva.Estado.ToString() // Convertimos el Enum a texto
            };
        }
    }
}