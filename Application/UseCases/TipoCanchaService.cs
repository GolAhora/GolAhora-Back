using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class TipoCanchaService : ITipoCanchaService
    {
        private readonly IQueryTipoCancha _query;
        private readonly ICommandTipoCancha _command;

        public TipoCanchaService(IQueryTipoCancha query, ICommandTipoCancha command)
        {
            _query = query;
            _command = command;
        }

        public async Task<TipoCanchaResponse> ConsultarTipoCanchaPorId(Guid id)
        {
            var tipoCancha = await _query.ConsultarTipoCanchaPorId(id);
            if (tipoCancha == null) throw new Exception($"No existe un tipo de cancha con el ID {id}.");
            return Mapear(tipoCancha);
        }

        public async Task<IList<TipoCanchaResponse>> ConsultarTiposCancha()
        {
            var tipos = await _query.ConsultarTiposCancha();
            return tipos.Select(Mapear).ToList();
        }

        public async Task<TipoCanchaResponse> CrearTipoCancha(TipoCanchaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Nombre))
                throw new Exception("El nombre del tipo de cancha es obligatorio.");

            var nuevo = new TipoCancha
            {
                Nombre       = request.Nombre,
                Superficie   = request.Superficie,
                Capacidad    = request.Capacidad,
                DuracionMax  = request.DuracionMax,
                PrecioBaseHora = request.PrecioBaseHora
            };

            var creado = await _command.CrearTipoCancha(nuevo);
            return Mapear(creado);
        }

        public async Task<TipoCanchaResponse> ActualizarTipoCancha(Guid id, TipoCanchaRequest request)
        {
            var existente = await _query.ConsultarTipoCanchaPorId(id);
            if (existente == null) throw new Exception($"No existe un tipo de cancha con el ID {id}.");

            var modificado = new TipoCancha
            {
                Nombre       = request.Nombre ?? existente.Nombre,
                Superficie   = request.Superficie != 0 ? request.Superficie : existente.Superficie,
                Capacidad    = request.Capacidad  != 0 ? request.Capacidad  : existente.Capacidad,
                DuracionMax  = request.DuracionMax  != 0 ? request.DuracionMax  : existente.DuracionMax,
                PrecioBaseHora = request.PrecioBaseHora != 0 ? request.PrecioBaseHora : existente.PrecioBaseHora
            };

            var resultado = await _command.ModificarTipoCancha(id, modificado);
            return Mapear(resultado!);
        }

        public async Task<TipoCanchaResponse> EliminarTipoCancha(Guid id)
        {
            var existente = await _query.ConsultarTipoCanchaPorId(id);
            if (existente == null) throw new Exception($"No existe un tipo de cancha con el ID {id}.");

            await _command.EliminarTipoCancha(id);
            return Mapear(existente);
        }

        private TipoCanchaResponse Mapear(TipoCancha tc) => new TipoCanchaResponse
        {
            Id             = tc.Id,
            Nombre         = tc.Nombre,
            Superficie     = tc.Superficie,
            Capacidad      = tc.Capacidad,
            DuracionMax    = tc.DuracionMax,
            PrecioBaseHora = tc.PrecioBaseHora
        };
    }
}
