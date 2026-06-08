using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases
{
    public class CobroService : ICobroService
    {
        private readonly IQueryCobro   _query;
        private readonly ICommandCobro  _command;
        private readonly ICommandRecibo _commandRecibo;

        public CobroService(IQueryCobro query, ICommandCobro command, ICommandRecibo commandRecibo)
        {
            _query         = query;
            _command       = command;
            _commandRecibo = commandRecibo;
        }

        public async Task<CobroResponse> ConsultarCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id)
                ?? throw new Exception("Cobro no encontrado.");
            return Mapear(cobro);
        }

        public async Task<IList<CobroResponse>> ConsultarCobros()
        {
            var cobros = await _query.ObtenerTodosAsync();
            return cobros.Select(Mapear).ToList();
        }

        public async Task<IList<CobroResponse>> ConsultarCobroPorFecha(DateTime fecha)
        {
            var cobros = await _query.ObtenerPorFechaAsync(fecha);
            return cobros.Select(Mapear).ToList();
        }


        public async Task<IList<CobroResponse>> ConsultarCobros(DateTime fecha)
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

        public async Task<CobroResponse> RegistrarCobro(CobroRequest request)
        {
            if (request.MontoFinal <= 0)
                throw new Exception("El monto del cobro debe ser mayor a cero.");

            var nuevo = new Cobro
            {
                ReferenciaId   = request.ReferenciaId,
                MedioPago      = request.MedioPago,
                MontoFinal     = request.MontoFinal,
                MontoOriginal  = request.MontoFinal,
                Fecha          = DateTime.UtcNow,
                Estado         = Estado.Pendiente
            };

            await _command.AgregarAsync(nuevo);
            return Mapear(nuevo);
        }

        public async Task<CobroResponse> ModificarCobro(Guid id, CobroRequest request)
        {
            var cobro = await _query.ObtenerPorIdAsync(id)
                ?? throw new Exception("El cobro que intenta modificar no existe.");

            cobro.ReferenciaId = request.ReferenciaId;
            cobro.MedioPago    = request.MedioPago;
            cobro.MontoFinal   = request.MontoFinal;

            await _command.ModificarAsync(cobro);
            return Mapear(cobro);
        }

        public async Task<CobroResponse> EliminarCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id)
                ?? throw new Exception("El cobro no existe.");

            await _command.EliminarAsync(id);
            return Mapear(cobro);
        }

        public async Task<CobroResponse> ValidarCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id)
                ?? throw new Exception("Cobro no encontrado.");

            cobro.Estado = Estado.Confirmada;
            await _command.ModificarAsync(cobro);
            return Mapear(cobro);
        }

        public async Task<ReciboResponse> GenerarReciboDeCobro(Guid id)
        {
            var cobro = await _query.ObtenerPorIdAsync(id)
                ?? throw new Exception("Cobro no encontrado.");

            if (cobro.Estado != Estado.Confirmada)
                throw new Exception("Solo se puede generar recibo de un cobro confirmado.");

            if (cobro.Recibo != null)
                throw new Exception("Este cobro ya tiene un recibo generado.");

            var recibo = new Recibo
            {
                CobroId           = cobro.Id,
                FechaEmision      = DateTime.UtcNow,
                NumeroComprobante = new Random().Next(100000, 999999),
                MontoTotal        = cobro.MontoFinal
            };

            await _commandRecibo.AgregarAsync(recibo);

            return new ReciboResponse
            {
                Id                = recibo.Id,
                CobroId           = recibo.CobroId,
                FechaEmision      = recibo.FechaEmision,
                NumeroComprobante = recibo.NumeroComprobante,
                MontoTotal        = recibo.MontoTotal
            };
        }

        private static CobroResponse Mapear(Cobro c) => new CobroResponse
        {
            Id            = c.Id,
            MontoOriginal = c.MontoOriginal,
            MontoFinal    = c.MontoFinal,
            Fecha         = c.Fecha,
            Estado        = c.Estado.ToString(),
            MedioPago     = c.MedioPago,
            ReferenciaId  = c.ReferenciaId
        };

    }
}
