using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar los casos de uso relacionados con Reservas
    public class ServiceReserva : IServiceReserva
    {
        // Query se utiliza para consultar información
        private readonly IQueryReserva _query;

        // Command se utiliza para guardar, modificar o eliminar información
        private readonly ICommandReserva _command;

        // Constructor
        public ServiceReserva(IQueryReserva query, ICommandReserva command)
        {
            _query = query;
            _command = command;
        }

        // CONSULTAR UNA RESERVA
        public async Task<ReservaResponse> ConsultarReserva(Guid id)
        {
            // Busco la reserva por Id
            Reserva reserva = await _query.ObtenerPorIdAsync(id);

            // Verifico que exista
            if (reserva == null)
            {
                throw new Exception("La reserva solicitada no existe.");
            }

            // Devuelvo la reserva convertida a Response
            return Mapear(reserva);
        }

        // CONSULTAR TODAS LAS RESERVAS
        public async Task<IList<ReservaResponse>> ConsultarReservas()
        {
            // Obtengo todas las reservas
            IList<Reserva> reservas = await _query.ObtenerTodosAsync();

            // Lista donde guardaré las respuestas
            List<ReservaResponse> listaReservas = new List<ReservaResponse>();

            // Recorro cada reserva
            foreach (Reserva reserva in reservas)
            {
                listaReservas.Add(Mapear(reserva));
            }

            // Devuelvo la lista completa
            return listaReservas;
        }


        // CREAR RESERVA
        public async Task<ReservaResponse> CrearReserva(ReservaRequest request)
        {
            // Regla de negocio:
            // La hora de inicio debe ser menor a la hora de fin
            if (request.HoraInicio >= request.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser anterior a la hora de fin.");
            }

            // Creo una nueva reserva
            Reserva nuevaReserva = new Reserva();

            nuevaReserva.UsuarioId = request.UsuarioId;
            nuevaReserva.CanchaId = request.CanchaId;
            nuevaReserva.Fecha = request.Fecha;
            nuevaReserva.HoraInicio = request.HoraInicio;
            nuevaReserva.HoraFin = request.HoraFin;

            // Estado inicial de la reserva
            nuevaReserva.Estado = EstadoReserva.Confirmada;

            // Guardo la reserva
            await _command.AgregarAsync(nuevaReserva);

            // Devuelvo la respuesta
            return Mapear(nuevaReserva);
        }

        // MODIFICAR RESERVA
        public async Task<ReservaResponse> ModificarReserva(Guid id, ReservaRequest request)
        {
            // Busco la reserva existente
            Reserva reservaExistente = await _query.ObtenerPorIdAsync(id);

            // Verifico que exista
            if (reservaExistente == null)
            {
                throw new Exception("La reserva que intenta modificar no existe.");
            }

            // Valido horarios
            if (request.HoraInicio >= request.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser anterior a la hora de fin.");
            }

            // Actualizo los datos
            reservaExistente.CanchaId = request.CanchaId;
            reservaExistente.UsuarioId = request.UsuarioId;
            reservaExistente.Fecha = request.Fecha;
            reservaExistente.HoraInicio = request.HoraInicio;
            reservaExistente.HoraFin = request.HoraFin;

            // Guardo los cambios
            await _command.ModificarAsync(reservaExistente);

            // Devuelvo la respuesta
            return Mapear(reservaExistente);
        }

        // CANCELAR RESERVA
        public async Task<ReservaResponse> CancelarReserva(Guid id)
        {
            // Busco la reserva
            Reserva reserva = await _query.ObtenerPorIdAsync(id);

            // Verifico que exista
            if (reserva == null)
            {
                throw new Exception("La reserva que intenta cancelar no existe.");
            }

            // Cambio el estado a Cancelada
            reserva.Estado = EstadoReserva.Cancelada;

            // Guardo el cambio
            await _command.ModificarAsync(reserva);

            // Devuelvo la reserva actualizada
            return Mapear(reserva);
        }

        // MÉTODO PENDIENTE
        public Task<ReservaResponse> RegistrarReserva(Guid id)
        {
            throw new NotImplementedException(
                "Este método parece duplicado. Ya existe CrearReserva(ReservaRequest)."
            );
        }

        // MÉTODO PRIVADO DE MAPEO
        // Convierte una entidad Reserva en ReservaResponse
        private ReservaResponse Mapear(Reserva reserva)
        {
            ReservaResponse respuesta = new ReservaResponse();

            respuesta.Id = reserva.Id;
            respuesta.UsuarioId = reserva.UsuarioId;
            respuesta.CanchaId = reserva.CanchaId;
            respuesta.Fecha = reserva.Fecha;
            respuesta.HoraInicio = reserva.HoraInicio;
            respuesta.HoraFin = reserva.HoraFin;

            // Convertimos el Enum a texto para mostrarlo
            respuesta.Estado = reserva.Estado.ToString();

            return respuesta;
        }
    }
}