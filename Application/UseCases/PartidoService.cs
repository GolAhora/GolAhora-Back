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
using System.Threading.Tasks;

namespace Application.UseCases
{
    // Servicio encargado de ser el "cerebro" de los Partidos
    public class ServicePartido : IServicePartido
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryPartido _query;
        private readonly ICommandPartido _command;

        // Constructor: C# inyecta estas herramientas automáticamente
        public ServicePartido(IQueryPartido query, ICommandPartido command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<PartidoResponse> ConsultarPartido(Guid id)
        {
            var partido = await _query.ObtenerPorIdAsync(id);

            if (partido == null) throw new Exception("Partido no encontrado.");

            return Mapear(partido);
        }

        public async Task<IList<PartidoResponse>> ConsultarPartidos()
        {
            var partidos = await _query.ObtenerTodosAsync();

            // Magia LINQ: Traducimos toda la lista a Response en un solo paso
            return partidos.Select(Mapear).ToList();
        }

        public async Task<PartidoResponse> RegistrarPartido(PartidoRequest request)
        {
            // Armamos el nuevo partido completo en un solo bloque (Object Initializer)
            var nuevoPartido = new Partido
            {
                Fecha = request.Fecha,
                EquipoLocal = request.EquipoLocal,
                EquipoVisitante = request.EquipoVisitante,
                GolesLocal = request.GolesLocal,
                GolesVisitante = request.GolesVisitante,
                CompetenciaId = request.CompetenciaId,
                // Usamos tu regla de negocio inteligente para determinar el ganador
                Resultado = ObtenerResultado(request.GolesLocal, request.GolesVisitante)
            };

            await _command.AgregarAsync(nuevoPartido);

            return Mapear(nuevoPartido);
        }

        public async Task<PartidoResponse> ModificarPartido(Guid id, PartidoRequest request)
        {
            var partidoExistente = await _query.ObtenerPorIdAsync(id);

            if (partidoExistente == null) throw new Exception("El partido no existe en el sistema.");

            // Pisamos los datos permitidos
            partidoExistente.Fecha = request.Fecha;
            partidoExistente.EquipoLocal = request.EquipoLocal;
            partidoExistente.EquipoVisitante = request.EquipoVisitante;
            partidoExistente.GolesLocal = request.GolesLocal;
            partidoExistente.GolesVisitante = request.GolesVisitante;
            partidoExistente.CompetenciaId = request.CompetenciaId;

            // Recalculamos por si cambiaron los goles
            partidoExistente.Resultado = ObtenerResultado(request.GolesLocal, request.GolesVisitante);

            await _command.ModificarAsync(partidoExistente);

            return Mapear(partidoExistente);
        }

        public async Task<PartidoResponse> EliminarPartido(Guid id)
        {
            var partido = await _query.ObtenerPorIdAsync(id);

            if (partido == null) throw new Exception("El partido que intenta eliminar no existe.");

            await _command.EliminarAsync(id);

            return Mapear(partido);
        }


        // --- 2. MÉTODOS PRIVADOS Y REGLAS DE NEGOCIO ---

        // Determina el texto del resultado según los goles de cada equipo
        private string ObtenerResultado(int golesLocal, int golesVisitante)
        {
            if (golesLocal > golesVisitante) return "Victoria Local";

            if (golesVisitante > golesLocal) return "Victoria Visitante";

            return "Empate";
        }


        // --- 3. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la entidad en un objeto de respuesta seguro para la pantalla
        private PartidoResponse Mapear(Partido partido)
        {
            return new PartidoResponse
            {
                Id = partido.Id,
                Fecha = partido.Fecha,
                EquipoLocal = partido.EquipoLocal,
                EquipoVisitante = partido.EquipoVisitante,
                GolesLocal = partido.GolesLocal,
                GolesVisitante = partido.GolesVisitante,
                Resultado = partido.Resultado,
                CompetenciaId = partido.CompetenciaId
            };
        }
    }
}