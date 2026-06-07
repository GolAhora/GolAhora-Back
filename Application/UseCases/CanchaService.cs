using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.UseCases
{

    public class CanchaService : ICanchaService
    {

        private readonly IQueryCancha _query;
        private readonly ICommandCancha _command;


        public CanchaService(IQueryCancha query, ICommandCancha command)
        {
            _query = query;
            _command = command;
        }
        
        public async Task<CanchaResponse> ConsultarCanchaPorId(Guid id)
        {
            var cancha = await _query.ConsultarCanchaPorId(id);

            if (cancha == null) throw new Exception("La cancha solicitada no existe.");

            CanchaResponse canchaResponse = new CanchaResponse
            {
                   Id = cancha.Id,
                        Numero = cancha.Numero,
                        TipoCancha = new TipoCanchaResponse
                        {
                            Id = cancha.TipoCanchaId,
                            Nombre = cancha.TipoCancha.Nombre
                        },
                        Estado = cancha.Estado
            };

            return canchaResponse;
        }  

        public async Task<IList<CanchaResponse>> ConsultarCanchas()
        {
            var canchas = await _query.ConsultarCanchas();

            IList<CanchaResponse> response = new List<CanchaResponse>();
            foreach (var cancha in canchas)
            {
                CanchaResponse canchaResponse = new CanchaResponse
                {
                        Id = cancha.Id,
                        Numero = cancha.Numero,
                        TipoCancha = new TipoCanchaResponse
                        {
                            Id = cancha.TipoCanchaId,
                            Nombre = cancha.TipoCancha.Nombre
                        },
                        Estado = cancha.Estado
                };
          
                response.Add(canchaResponse);
            }
            return response;
        }

        public async Task<CanchaResponse> CrearCancha(CanchaRequest request)
        {

            Cancha nuevaCancha = new Cancha
            {
                Numero = (int)request.Numero,
                TipoCanchaId = request.TipoCanchaId,
                Estado = EstadoCancha.Disponible
            };
            Cancha create  = await _command.CrearCancha(nuevaCancha);

            CanchaResponse canchaResponse = new CanchaResponse
            {
                Id = create.Id,
                Numero = create.Numero,
                TipoCancha = new TipoCanchaResponse
                {
                    Id = create.TipoCancha.Id,
                    Nombre = create.TipoCancha.Nombre,
                    Capacidad = create.TipoCancha.Capacidad,
                    DuracionMax = create.TipoCancha.DuracionMax,
                    PrecioBaseHora = create.TipoCancha.PrecioBaseHora,
                    Superficie = create.TipoCancha.Superficie
                },
                Estado = create.Estado
            };

            return canchaResponse;
        }

        public async Task<CanchaResponse> ActualizarCancha(Guid id, CanchaRequest request)
        {
            var canchaExistente = await _query.ConsultarCanchaPorId(id);

            if (canchaExistente == null) throw new Exception("La cancha que intenta modificar no existe.");
        
            var canchaModificada = new Cancha
            {
                Id = canchaExistente.Id,
                Numero = request.Numero ?? canchaExistente.Numero,
                Estado = request.Estado ?? canchaExistente.Estado
            };

            var nc = await _command.ModificarCancha(id, canchaModificada);

             return new CanchaResponse
             {
                Id = nc.Id,
                Numero = nc.Numero, 
                Estado = nc.Estado,
            };

        }

        public async Task<CanchaResponse> EliminarCancha(Guid id)
        {

            Cancha? d = await _command.EliminarCancha(id);

            CanchaResponse canchaResponse = new CanchaResponse
            {
                Id = d.Id,
                Numero = d.Numero,
                Estado = d.Estado,
                TipoCancha = new TipoCanchaResponse
                {
                    Id = d.TipoCancha.Id,
                    Nombre = d.TipoCancha.Nombre,
                    Capacidad = d.TipoCancha.Capacidad,
                    DuracionMax = d.TipoCancha.DuracionMax,
                    PrecioBaseHora = d.TipoCancha.PrecioBaseHora,
                    Superficie = d.TipoCancha.Superficie
                }
            };

            return canchaResponse;
        }



      
        public async Task<bool> ActualizarDisponibildiad(Guid id, bool disponible)
        {
            var cancha = await _query.ConsultarCanchaPorId(id);

            if (cancha == null) return false;

        
            cancha.Estado = disponible ? EstadoCancha.Disponible : EstadoCancha.Ocupada;

            await _command.ModificarCancha(id, cancha);

            return true;
        }

        public async Task<bool> ConsultarDisponibildiad(Guid id, bool disponible)
        {
            bool d = await _query.ConsultarDisponibildiad(id);
            return d; 
        }


    }
}
