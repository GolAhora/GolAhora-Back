using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar las operaciones relacionadas con Canchas
    public class ServiceCancha : IServiceCancha
    {
        // Referencias a Query y Command
        private readonly IQueryCancha _query;
        private readonly ICommandCancha _command;

        // Constructor
        public ServiceCancha(IQueryCancha query, ICommandCancha command)
        {
            _query = query;
            _command = command;
        }

        // Busca una cancha por su Id
        public async Task<CanchaResponse> ConsultarCanchaPorId(Guid id)
        {
            Cancha cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null)
            {
                throw new Exception("La cancha solicitada no existe.");
            }

            return Mapear(cancha);
        }

        // Devuelve todas las canchas
        public async Task<IList<CanchaResponse>> ConsultarCanchas()
        {
            IList<Cancha> canchas = await _query.ObtenerTodosAsync();

            List<CanchaResponse> listaCanchas =
                new List<CanchaResponse>();

            foreach (Cancha cancha in canchas)
            {
                listaCanchas.Add(Mapear(cancha));
            }

            return listaCanchas;
        }

        // Crea una nueva cancha
        public async Task<CanchaResponse> CrearCancha(CanchaRequest request)
        {
            Cancha nuevaCancha = new Cancha();

            nuevaCancha.Numero = request.Numero;
            nuevaCancha.TipoCanchaId = request.TipoCanchaId;

            // Toda cancha nueva comienza disponible
            nuevaCancha.Estado = EstadoCancha.Disponible;

            await _command.AgregarAsync(nuevaCancha);

            return Mapear(nuevaCancha);
        }

        // Modifica una cancha existente
        public async Task<CanchaResponse> ActualizarCancha(
            Guid id,
            CanchaRequest request)
        {
            Cancha canchaExistente =
                await _query.ObtenerPorIdAsync(id);

            if (canchaExistente == null)
            {
                throw new Exception(
                    "La cancha que intenta modificar no existe.");
            }

            canchaExistente.Numero = request.Numero;
            canchaExistente.TipoCanchaId =
                request.TipoCanchaId;

            await _command.ModificarAsync(canchaExistente);

            return Mapear(canchaExistente);
        }

        // Elimina una cancha
        public async Task<CanchaResponse> EliminarCancha(Guid id)
        {
            Cancha cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null)
            {
                throw new Exception(
                    "La cancha que intenta eliminar no existe.");
            }

            await _command.EliminarAsync(id);

            return Mapear(cancha);
        }

        // Actualiza el estado de disponibilidad de una cancha
        public async Task<bool> ActualizarDisponibildiad(
            Guid id,
            bool disponible)
        {
            Cancha cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null)
            {
                return false;
            }

            if (disponible)
            {
                cancha.Estado = EstadoCancha.Disponible;
            }
            else
            {
                cancha.Estado = EstadoCancha.Ocupada;
            }

            await _command.ModificarAsync(cancha);

            return true;
        }

        // Consulta si una cancha está disponible
        public async Task<bool> ConsultarDisponibildiad(
            Guid id,
            bool disponible)
        {
            Cancha cancha = await _query.ObtenerPorIdAsync(id);

            if (cancha == null)
            {
                throw new Exception("Cancha no encontrada.");
            }

            return cancha.Estado ==
                   EstadoCancha.Disponible;
        }

        // Cambia el estado de la cancha a mantenimiento
        public async Task<CanchaResponse>
            ProgramarMantenimientoACancha(
            Guid idCancha,
            Guid idMantenimiento)
        {
            Cancha cancha =
                await _query.ObtenerPorIdAsync(idCancha);

            if (cancha == null)
            {
                throw new Exception("Cancha no encontrada.");
            }

            cancha.Estado = EstadoCancha.Mantenimiento;

            await _command.ModificarAsync(cancha);

            return Mapear(cancha);
        }

        // Finaliza un mantenimiento y deja la cancha disponible
        public async Task<CanchaResponse>
            CancelarMantenimientoACancha(
            Guid idCancha,
            Guid idMantenimiento)
        {
            Cancha cancha =
                await _query.ObtenerPorIdAsync(idCancha);

            if (cancha == null)
            {
                throw new Exception("Cancha no encontrada.");
            }

            cancha.Estado = EstadoCancha.Disponible;

            await _command.ModificarAsync(cancha);

            return Mapear(cancha);
        }

        // Pendiente de implementar
        public Task<CanchaResponse>
            ConsultarMantenimientoDeCancha(Guid idCancha)
        {
            throw new NotImplementedException(
                "Falta implementar la consulta de mantenimientos.");
        }

        // Convierte una entidad Cancha en CanchaResponse
        private CanchaResponse Mapear(Cancha cancha)
        {
            CanchaResponse respuesta =
                new CanchaResponse();

            respuesta.Id = cancha.Id;
            respuesta.Numero = cancha.Numero;

            // Convertimos el Enum a texto
            respuesta.Estado =
                cancha.Estado.ToString();

            // Por ahora mostramos el Id del tipo de cancha
            respuesta.TipoCanchaNombre =
                cancha.TipoCanchaId.ToString();

            return respuesta;
        }
    }
}