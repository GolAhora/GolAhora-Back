using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar los cobros
    public class ServiceCobro : IServiceCobro
    {
        // Referencias a Query y Command
        private readonly IQueryCobro _query;
        private readonly ICommandCobro _command;

        // Constructor
        public ServiceCobro(IQueryCobro query, ICommandCobro command)
        {
            _query = query;
            _command = command;
        }

        // Busca un cobro por su Id
        public async Task<CobroResponse> ConsultarCobro(Guid id)
        {
            Cobro cobro = await _query.ObtenerPorIdAsync(id);

            if (cobro == null)
            {
                throw new Exception("Cobro no encontrado.");
            }

            return Mapear(cobro);
        }

        // Devuelve todos los cobros registrados
        public async Task<IList<CobroResponse>> ConsultarCobros()
        {
            IList<Cobro> cobros = await _query.ObtenerTodosAsync();

            List<CobroResponse> listaCobros =
                new List<CobroResponse>();

            foreach (Cobro cobro in cobros)
            {
                listaCobros.Add(Mapear(cobro));
            }

            return listaCobros;
        }

        // Registra un nuevo cobro
        public async Task<CobroResponse> RegistrarCobro(
            CobroRequest request)
        {
            // Validamos que el monto sea correcto
            if (request.MontoFinal <= 0)
            {
                throw new Exception(
                    "El monto del cobro debe ser mayor a cero.");
            }

            // Creamos un nuevo cobro
            Cobro nuevoCobro = new Cobro();

            nuevoCobro.ReferenciaId = request.ReferenciaId;
            nuevoCobro.MedioPago = request.MedioPago;
            nuevoCobro.MontoFinal = request.MontoFinal;

            // Inicialmente ambos montos son iguales
            nuevoCobro.MontoOriginal = request.MontoFinal;

            // Guardamos la fecha actual
            nuevoCobro.Fecha = DateTime.Now;

            // El cobro comienza pendiente
            nuevoCobro.Estado = EstadoCobro.Pendiente;

            await _command.AgregarAsync(nuevoCobro);

            return Mapear(nuevoCobro);
        }

        // Elimina un cobro
        public async Task<CobroResponse> EliminarCobro(Guid id)
        {
            Cobro cobro = await _query.ObtenerPorIdAsync(id);

            if (cobro == null)
            {
                throw new Exception("El cobro no existe.");
            }

            await _command.EliminarAsync(id);

            return Mapear(cobro);
        }

        // Confirma un cobro realizado
        public async Task<CobroResponse> ValidarCobro(Guid id)
        {
            Cobro cobro = await _query.ObtenerPorIdAsync(id);

            if (cobro == null)
            {
                throw new Exception("Cobro no encontrado.");
            }

            // Cambiamos el estado a confirmado
            cobro.Estado = EstadoCobro.Confirmada;

            await _command.ModificarAsync(cobro);

            return Mapear(cobro);
        }

        // Generar recibo pendiente de implementación
        public Task<CobroResponse> GenerarReciboDeCobro(Guid id)
        {
            throw new NotImplementedException(
                "Falta implementar la generación de recibos.");
        }

        // Imprimir cobro pendiente de implementación
        public Task<CobroResponse> ImprimirCobro(Guid id)
        {
            throw new NotImplementedException(
                "Falta implementar la impresión del cobro.");
        }

        // Pendiente de implementación
        public Task<CobroResponse> ModificarCobro(Guid id)
        {
            throw new NotImplementedException(
                "Falta agregar CobroRequest al método.");
        }

        // Pendiente de revisión
        public Task<CobroResponse> RealizarCobro(Guid id)
        {
            throw new NotImplementedException(
                "Método pendiente de revisión.");
        }

        // Pendiente de revisión
        public Task<CobroResponse> RegistrarCobro(Guid id)
        {
            throw new NotImplementedException(
                "Método pendiente de revisión.");
        }

        // Pendiente de implementación
        public Task<CobroResponse> ConsultarCobroPorFecha(
            DateTime fecha)
        {
            throw new NotImplementedException();
        }

        // Pendiente de implementación
        public Task<CobroResponse> ConsultarCobroPorReserva(
            Guid id)
        {
            throw new NotImplementedException();
        }

        // Pendiente de implementación
        public Task<CobroResponse> ConsultarCobroPorUsuario(
            Guid id)
        {
            throw new NotImplementedException();
        }

        // Convierte una entidad Cobro en CobroResponse
        private CobroResponse Mapear(Cobro cobro)
        {
            CobroResponse respuesta =
                new CobroResponse();

            respuesta.Id = cobro.Id;
            respuesta.MontoOriginal = cobro.MontoOriginal;
            respuesta.MontoFinal = cobro.MontoFinal;
            respuesta.Fecha = cobro.Fecha;

            // Convertimos el Enum a texto
            respuesta.Estado =
                cobro.Estado.ToString();

            respuesta.MedioPago = cobro.MedioPago;
            respuesta.ReferenciaId = cobro.ReferenciaId;

            return respuesta;
        }
    }
}