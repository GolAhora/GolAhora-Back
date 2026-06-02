using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar todas las operaciones relacionadas con Recibos
    public class ServiceRecibo : IServiceRecibo
    {
        // Query se utiliza para consultar información
        private readonly IQueryRecibo _query;

        // Command se utiliza para guardar, modificar y eliminar información
        private readonly ICommandRecibo _command;

        // Constructor
        public ServiceRecibo(IQueryRecibo query, ICommandRecibo command)
        {
            _query = query;
            _command = command;
        }

        // Consulta un recibo por su Id
        public async Task<ReciboResponse> ConsultarRecibo(Guid id)
        {
            // Busco el recibo en la base de datos
            Recibo recibo = await _query.ObtenerPorIdAsync(id);

            // Verifico que exista
            if (recibo == null)
            {
                throw new Exception("Recibo no encontrado.");
            }

            // Devuelvo el recibo convertido a Response
            return Mapear(recibo);
        }

        // Consulta todos los recibos registrados
        public async Task<IList<ReciboResponse>> ConsultarRecibos()
        {
            // Obtengo todos los recibos
            IList<Recibo> recibos = await _query.ObtenerTodosAsync();

            // Creo una lista para devolver la respuesta
            List<ReciboResponse> listaRecibos = new List<ReciboResponse>();

            // Recorro todos los recibos
            foreach (Recibo recibo in recibos)
            {
                listaRecibos.Add(Mapear(recibo));
            }

            return listaRecibos;
        }

        // Genera un nuevo recibo
        public async Task<ReciboResponse> GenerarRecibo(ReciboRequest request)
        {
            // Creo un nuevo objeto Recibo
            Recibo nuevoRecibo = new Recibo();

            // Asigno los datos recibidos
            nuevoRecibo.CobroId = request.CobroId;

            // Guardo la fecha actual
            nuevoRecibo.FechaEmision = DateTime.Now;

            // Genero un número de comprobante aleatorio
            Random random = new Random();
            nuevoRecibo.NumeroComprobante = random.Next(100000, 999999);

            // Por ahora asignamos 0 al monto total
            // Más adelante se podría obtener desde el cobro asociado
            nuevoRecibo.MontoTotal = 0;

            // Guardo el recibo
            await _command.AgregarAsync(nuevoRecibo);

            // Devuelvo el recibo creado
            return Mapear(nuevoRecibo);
        }

        // Modifica un recibo existente
        public async Task<ReciboResponse> ModificarRecibo(Guid id, ReciboRequest request)
        {
            // Busco el recibo
            Recibo reciboExistente = await _query.ObtenerPorIdAsync(id);

            // Verifico que exista
            if (reciboExistente == null)
            {
                throw new Exception("El recibo no existe.");
            }

            // Actualizo los datos permitidos
            reciboExistente.CobroId = request.CobroId;

            // Guardo los cambios
            await _command.ModificarAsync(reciboExistente);

            // Devuelvo el recibo actualizado
            return Mapear(reciboExistente);
        }

        // Elimina un recibo
        public async Task<ReciboResponse> EliminarRecibo(Guid id)
        {
            // Busco el recibo
            Recibo recibo = await _query.ObtenerPorIdAsync(id);

            // Verifico que exista
            if (recibo == null)
            {
                throw new Exception("El recibo que intenta eliminar no existe.");
            }

            // Lo elimino
            await _command.EliminarAsync(id);

            // Devuelvo los datos del recibo eliminado
            return Mapear(recibo);
        }

        // Consulta todos los recibos asociados a un usuario
        public async Task<IList<ReciboResponse>> ConsultarRecibosPorUsuario(Guid idUsuario)
        {
            // Obtengo los recibos del usuario
            IList<Recibo> recibos = await _query.ObtenerPorUsuarioAsync(idUsuario);

            // Creo una lista de respuestas
            List<ReciboResponse> listaRecibos = new List<ReciboResponse>();

            // Recorro todos los recibos encontrados
            foreach (Recibo recibo in recibos)
            {
                listaRecibos.Add(Mapear(recibo));
            }

            return listaRecibos;
        }

        // Método privado que convierte una entidad Recibo
        // en un objeto ReciboResponse
        private ReciboResponse Mapear(Recibo recibo)
        {
            ReciboResponse respuesta = new ReciboResponse();

            respuesta.Id = recibo.Id;
            respuesta.NumeroComprobante = recibo.NumeroComprobante;
            respuesta.FechaEmision = recibo.FechaEmision;
            respuesta.MontoTotal = recibo.MontoTotal;
            respuesta.CobroId = recibo.CobroId;

            return respuesta;
        }
    }
}