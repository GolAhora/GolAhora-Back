using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de manejar todas las operaciones relacionadas con Partidos
    public class ServicePartido : IServicePartido
    {
        // Referencias a Query (lectura) y Command (escritura)
        private readonly IQueryPartido _query;
        private readonly ICommandPartido _command;

        // Constructor
        public ServicePartido(
            IQueryPartido query,
            ICommandPartido command)
        {
            _query = query;
            _command = command;
        }

        // Busca un partido por su Id
        public async Task<PartidoResponse> ConsultarPartido(Guid id)
        {
            Partido partido =
                await _query.ObtenerPorIdAsync(id);

            // Verificamos que exista
            if (partido == null)
            {
                throw new Exception(
                    "Partido no encontrado.");
            }

            return Mapear(partido);
        }

        // Devuelve todos los partidos registrados
        public async Task<IList<PartidoResponse>> ConsultarPartidos()
        {
            IList<Partido> partidos =
                await _query.ObtenerTodosAsync();

            List<PartidoResponse> listaPartidos =
                new List<PartidoResponse>();

            // Recorremos la lista y convertimos cada partido
            foreach (Partido partido in partidos)
            {
                listaPartidos.Add(
                    Mapear(partido));
            }

            return listaPartidos;
        }

        // Registra un nuevo partido
        public async Task<PartidoResponse> RegistrarPartido(
            PartidoRequest request)
        {
            // Calculamos el resultado según los goles
            string resultadoCalculado =
                ObtenerResultado(
                    request.GolesLocal,
                    request.GolesVisitante);

            // Creamos el nuevo partido
            Partido nuevoPartido =
                new Partido();

            nuevoPartido.Fecha =
                request.Fecha;

            nuevoPartido.EquipoLocal =
                request.EquipoLocal;

            nuevoPartido.EquipoVisitante =
                request.EquipoVisitante;

            nuevoPartido.GolesLocal =
                request.GolesLocal;

            nuevoPartido.GolesVisitante =
                request.GolesVisitante;

            nuevoPartido.Resultado =
                resultadoCalculado;

            nuevoPartido.CompetenciaId =
                request.CompetenciaId;

            // Guardamos el partido
            await _command.AgregarAsync(
                nuevoPartido);

            return Mapear(nuevoPartido);
        }

        // Modifica un partido existente
        public async Task<PartidoResponse> ModificarPartido(
            Guid id,
            PartidoRequest request)
        {
            Partido partidoExistente =
                await _query.ObtenerPorIdAsync(id);

            // Verificamos que exista
            if (partidoExistente == null)
            {
                throw new Exception(
                    "El partido no existe en el sistema.");
            }

            // Recalculamos el resultado
            string resultadoCalculado =
                ObtenerResultado(
                    request.GolesLocal,
                    request.GolesVisitante);

            // Actualizamos los datos
            partidoExistente.Fecha =
                request.Fecha;

            partidoExistente.EquipoLocal =
                request.EquipoLocal;

            partidoExistente.EquipoVisitante =
                request.EquipoVisitante;

            partidoExistente.GolesLocal =
                request.GolesLocal;

            partidoExistente.GolesVisitante =
                request.GolesVisitante;

            partidoExistente.Resultado =
                resultadoCalculado;

            partidoExistente.CompetenciaId =
                request.CompetenciaId;

            // Guardamos los cambios
            await _command.ModificarAsync(
                partidoExistente);

            return Mapear(partidoExistente);
        }

        // Elimina un partido
        public async Task<PartidoResponse> EliminarPartido(
            Guid id)
        {
            Partido partido =
                await _query.ObtenerPorIdAsync(id);

            // Verificamos que exista
            if (partido == null)
            {
                throw new Exception(
                    "El partido que intenta eliminar no existe.");
            }

            // Eliminamos el registro
            await _command.EliminarAsync(id);

            return Mapear(partido);
        }


        // MÉTODOS PRIVADOS


        // Determina automáticamente el resultado
        // según la cantidad de goles de cada equipo
        private string ObtenerResultado(
            int golesLocal,
            int golesVisitante)
        {
            if (golesLocal > golesVisitante)
            {
                return "Victoria Local";
            }

            if (golesVisitante > golesLocal)
            {
                return "Victoria Visitante";
            }

            return "Empate";
        }

        // Convierte una entidad Partido
        // en un objeto PartidoResponse
        private PartidoResponse Mapear(
            Partido partido)
        {
            PartidoResponse respuesta =
                new PartidoResponse();

            respuesta.Id = partido.Id;
            respuesta.Fecha = partido.Fecha;
            respuesta.EquipoLocal = partido.EquipoLocal;
            respuesta.EquipoVisitante = partido.EquipoVisitante;
            respuesta.GolesLocal = partido.GolesLocal;
            respuesta.GolesVisitante = partido.GolesVisitante;
            respuesta.Resultado = partido.Resultado;
            respuesta.CompetenciaId = partido.CompetenciaId;

            return respuesta;
        }
    }
}