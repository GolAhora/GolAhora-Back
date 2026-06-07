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
    // Servicio encargado de ser el "cerebro" de los Recibos
    public class ReciboService : IReciboService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryRecibo _query;
        private readonly ICommandRecibo _command;

        // Constructor: C# inyecta estas herramientas automáticamente
        public ReciboService(IQueryRecibo query, ICommandRecibo command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<ReciboResponse> ConsultarRecibo(Guid id)
        {
            var recibo = await _query.ObtenerPorIdAsync(id);

            if (recibo == null) throw new Exception("Recibo no encontrado.");

            return Mapear(recibo);
        }

        public async Task<IList<ReciboResponse>> ConsultarRecibos()
        {
            var recibos = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista a Response en una sola línea
            return recibos.Select(Mapear).ToList();
        }

        public async Task<ReciboResponse> GenerarRecibo(ReciboRequest request)
        {
            // Generamos un número de comprobante aleatorio de 6 cifras
            var random = new Random();
            var numeroAleatorio = random.Next(100000, 999999);

            // Armamos el ticket de recibo completo en un solo bloque
            var nuevoRecibo = new Recibo
        {
                CobroId = request.CobroId,
                FechaEmision = DateTime.Now,
                NumeroComprobante = numeroAleatorio,

                // Nota arquitectónica: Lo ideal sería buscar el 'Cobro' en la BD 
                // para copiar su monto exacto. Por ahora lo dejamos en 0.
                MontoTotal = 0
            };

            await _command.AgregarAsync(nuevoRecibo);

            return Mapear(nuevoRecibo);
        }

        public async Task<ReciboResponse> ModificarRecibo(Guid id, ReciboRequest request)
        {
            var reciboExistente = await _query.ObtenerPorIdAsync(id);

            if (reciboExistente == null) throw new Exception("El recibo no existe.");

            // Regla de negocio: La fecha y el número de un recibo emitido no se pueden alterar.
            // Solo actualizamos el cobro asociado en caso de error.
            reciboExistente.CobroId = request.CobroId;

            await _command.ModificarAsync(reciboExistente);

            return Mapear(reciboExistente);
        }

        public async Task<ReciboResponse> EliminarRecibo(Guid id)
        {
            var recibo = await _query.ObtenerPorIdAsync(id);

            if (recibo == null) throw new Exception("El recibo que intenta eliminar no existe.");

            await _command.EliminarAsync(id);

            return Mapear(recibo);
        }


        // --- 2. BÚSQUEDAS ESPECÍFICAS ---

        public async Task<IList<ReciboResponse>> ConsultarRecibosPorUsuario(Guid idUsuario)
        {
            var recibos = await _query.ObtenerPorUsuarioAsync(idUsuario);

            // Convertimos la lista de resultados usando LINQ
            return recibos.Select(Mapear).ToList();
        }


        // --- 3. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la entidad de la BD en un objeto de respuesta seguro para la pantalla
        private ReciboResponse Mapear(Recibo recibo)
        {
            return new ReciboResponse
        {
                Id = recibo.Id,
                NumeroComprobante = recibo.NumeroComprobante,
                FechaEmision = recibo.FechaEmision,
                MontoTotal = recibo.MontoTotal,
                CobroId = recibo.CobroId
            };
        }
    }
}
