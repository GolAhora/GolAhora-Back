using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;

using Domain.Enums;

namespace Application.UseCases
{

    public class ReservaService : IReservaService
    {

        private readonly IQueryReserva _query;
        private readonly ICommandReserva _command;

        public ReservaService(IQueryReserva query, ICommandReserva command)
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

        public async Task<ReservaResponse?> ConsultarReservaActiva(Guid idCancha)
        {
            var reserva = await _query.ConsularReservaActiva(idCancha);

            if (reserva == null) throw new Exception("La reserva solicitada no existe.");

            return Mapear(reserva);
        }


        public async Task<IList<ReservaResponse>> ConsultarReservas()
        {
            var reservas = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista a Response en un solo paso
            return reservas.Select(Mapear).ToList();
        }

        public async Task<IList<ReservaResponse>> ConsultarReservasCancha(Guid idCancha)
        {
            var reservas = await _query.ConsultarReservasCancha(idCancha);

            return reservas
                .Select(Mapear)
                .ToList();
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
                Estado = Estado.Confirmada
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

            reserva.Estado = Estado.Cancelada;

            await _command.ModificarAsync(reserva);

            return Mapear(reserva);
        }


        private ReservaResponse Mapear(Reserva reserva)
{
    return new ReservaResponse
    {
        Id = reserva.Id,
        Fecha = reserva.Fecha,
        HoraInicio = reserva.HoraInicio,
        HoraFin = reserva.HoraFin,
        Estado = reserva.Estado,
        UsuarioId = reserva.UsuarioId,

        Cancha = reserva.Cancha == null ? null : new CanchaResponse
        {
            Id = reserva.Cancha.Id,
            Numero = reserva.Cancha.Numero,
            Estado = reserva.Cancha.Estado,

            TipoCancha =  new TipoCanchaResponse
            {
                Id = reserva.Cancha.TipoCancha.Id,
                Nombre = reserva.Cancha.TipoCancha.Nombre,
                Capacidad = reserva.Cancha.TipoCancha.Capacidad,
                DuracionMax = reserva.Cancha.TipoCancha.DuracionMax,
                PrecioBaseHora = reserva.Cancha.TipoCancha.PrecioBaseHora,
                Superficie = reserva.Cancha.TipoCancha.Superficie
            }
        }
    };
}


    }
}
