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
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;

namespace Application.UseCases
{
    // Servicio encargado de ser el "cerebro" de los Cobros
    public class ServiceCobro : ICobroService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryCobro _query;
        private readonly ICommandCobro _command;

        // Constructor: C# inyecta estas herramientas automáticamente
        public ServiceCobro(IQueryCobro query, ICommandCobro command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<CobroResponse> ConsultarCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id);

            if (cobro == null) throw new Exception("Cobro no encontrado.");

            return Mapear(cobro);
        }

        public async Task<IList<CobroResponse>> ConsultarCobros()
        {
            var cobros = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista en un solo paso
            return cobros.Select(Mapear).ToList();
        }

        public async Task<CobroResponse> RegistrarCobro(CobroRequest request)
        {
            // Regla de Negocio: No se pueden registrar cobros gratis o en negativo
            if (request.MontoFinal <= 0)
            {
                throw new Exception("El monto del cobro debe ser mayor a cero.");
            }

            // Armamos el "ticket" del cobro nuevo todo junto
            var nuevoCobro = new Cobro
            {
                ReferenciaId = request.ReferenciaId,
                MedioPago = request.MedioPago,
                MontoFinal = request.MontoFinal,
                MontoOriginal = request.MontoFinal, // Al nacer, no hay descuentos
                Fecha = DateTime.Now,
                Estado = EstadoCobro.Pendiente // Todo cobro nace pendiente hasta que se pague
            };

            await _command.AgregarAsync(nuevoCobro);

            return Mapear(nuevoCobro);
        }

        // ¡ATENCIÓN! Agregué 'CobroRequest request' porque sin él no sabríamos qué datos modificar
        public async Task<CobroResponse> ModificarCobro(Guid id, CobroRequest request)
        {
            var cobroExistente = await _query.ObtenerPorIdAsync(id);

            if (cobroExistente == null) throw new Exception("El cobro que intenta modificar no existe.");

            // Pisamos los datos permitidos
            cobroExistente.ReferenciaId = request.ReferenciaId;
            cobroExistente.MedioPago = request.MedioPago;
            cobroExistente.MontoFinal = request.MontoFinal;

            await _command.ModificarAsync(cobroExistente);

            return Mapear(cobroExistente);
        }

        public async Task<CobroResponse> EliminarCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id);

            if (cobro == null) throw new Exception("El cobro no existe.");

            await _command.EliminarAsync(id);

            return Mapear(cobro);
        }


        // --- 2. REGLAS DE NEGOCIO Y ESTADOS ---

        public async Task<CobroResponse> ValidarCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id);

            if (cobro == null) throw new Exception("Cobro no encontrado.");

            // Al validar, el pago ingresó correctamente
            cobro.Estado = EstadoCobro.Confirmada;

            await _command.ModificarAsync(cobro);

            return Mapear(cobro);
        }


        // --- 3. BÚSQUEDAS ESPECÍFICAS (Faltaban implementar) ---
        // ¡ATENCIÓN! Cambié el retorno a 'IList' porque puede haber más de un resultado.

        public async Task<IList<CobroResponse>> ConsultarCobroPorFecha(DateTime fecha)
        {
            var cobros = await _query.ObtenerPorFechaAsync(fecha);
            return cobros.Select(Mapear).ToList();
        }

        public async Task<IList<CobroResponse>> ConsultarCobroPorReserva(Guid idReserva)
        {
            var cobros = await _query.ObtenerPorReservaAsync(idReserva);
            return cobros.Select(Mapear).ToList();
        }

        public async Task<IList<CobroResponse>> ConsultarCobroPorUsuario(Guid idUsuario)
        {
            var cobros = await _query.ObtenerPorUsuarioAsync(idUsuario);
            return cobros.Select(Mapear).ToList();
        }


        // --- 5. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la entidad en un objeto de respuesta seguro para la pantalla
        private CobroResponse Mapear(Cobro cobro)
        {
            return new CobroResponse
        {
                Id = cobro.Id,
                MontoOriginal = cobro.MontoOriginal,
                MontoFinal = cobro.MontoFinal,
                Fecha = cobro.Fecha,
                Estado = cobro.Estado.ToString(), // Lo convertimos a texto
                MedioPago = cobro.MedioPago,
                ReferenciaId = cobro.ReferenciaId
            };
        }

        public Task<CobroResponse> ModificarCobro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> ImprimirCobro(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CobroResponse> GenerarReciboDeCobro(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
