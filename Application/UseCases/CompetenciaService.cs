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
using Domain.Enums;

namespace Application.UseCases
{
    // Servicio encargado de ser el "cerebro" de las Competencias.
    public class ServiceCompetencia : ICompetenciaService
    {
        // Herramientas para leer (_query) y escribir (_command) en la base de datos
        private readonly IQueryCompetencia _query;
        private readonly ICommandCompetencia _command;

        // Constructor: C# nos inyecta las herramientas automáticamente al arrancar
        public ServiceCompetencia(IQueryCompetencia query, ICommandCompetencia command)
        {
            _query = query;
            _command = command;
        }

        // --- 1. MÉTODOS BÁSICOS (CRUD) ---

        public async Task<CompetenciaResponse> ConsultarCompetencia(Guid id)
        {
            // Usamos 'var' para que el código sea más corto y limpio
            var competencia = await _query.ObtenerPorIdAsync(id);

            // Si la base de datos no encontró nada, frenamos todo y avisamos
            if (competencia == null)
            {
                throw new Exception("La competencia no existe.");
        }

            // Traducimos la entidad de la base de datos a un formato seguro para la pantalla
            return Mapear(competencia);
        }

        public async Task<IList<CompetenciaResponse>> ConsultarCompetencias()
        {
            // Traemos todas las competencias de la base de datos
            var competencias = await _query.ObtenerTodosAsync();

            // Creamos una caja vacía (lista) para guardar las respuestas
            var listaCompetencias = new List<CompetenciaResponse>();

            // Recorremos cada competencia, la traducimos (Mapear) y la guardamos en la caja
            foreach (var competencia in competencias)
            {
                listaCompetencias.Add(Mapear(competencia));
        }

            return listaCompetencias;
        }

        public async Task<CompetenciaResponse> RegistrarCompetencia(CompetenciaRequest request)
        {
            // Regla de oro: No se puede viajar en el tiempo
            if (request.FechaInicio > request.FechaFin)
            {
                throw new Exception("La fecha de inicio no puede ser posterior a la fecha de fin.");
        }

            // Armamos la nueva competencia en un solo bloque ordenado (Object Initializer)
            var nuevaCompetencia = new Competencia
        {
                Nombre = request.Nombre,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                ReglamentoOficial = request.ReglamentoOficial,
                ReglamentoInterno = request.ReglamentoInterno
            };

            // La guardamos en la base de datos
            await _command.AgregarAsync(nuevaCompetencia);

            return Mapear(nuevaCompetencia);
        }

        public async Task<CompetenciaResponse> ModificarCompetencia(Guid id, CompetenciaRequest request)
        {
            var competencia = await _query.ObtenerPorIdAsync(id);

            if (competencia == null) throw new Exception("Competencia no encontrada.");

            // Pisamos los datos viejos con los datos nuevos que llegaron en el 'request'
            competencia.Nombre = request.Nombre;
            competencia.FechaInicio = request.FechaInicio;
            competencia.FechaFin = request.FechaFin;
            competencia.ReglamentoOficial = request.ReglamentoOficial;
            competencia.ReglamentoInterno = request.ReglamentoInterno;

            // Guardamos los cambios
            await _command.ModificarAsync(competencia);

            return Mapear(competencia);
        }

        public async Task<CompetenciaResponse> EliminarCompetencia(Guid id)
        {
            var competencia = await _query.ObtenerPorIdAsync(id);

            if (competencia == null) throw new Exception("La competencia que intenta eliminar no existe.");

            // Borramos usando el ID
            await _command.EliminarAsync(id);

            return Mapear(competencia);
        }

        public async Task<CompetenciaResponse> OrganizarCompetencia(CompetenciaRequest request)
        {
            // Como organizar es lo mismo que registrar, reciclamos el código anterior
            return await RegistrarCompetencia(request);
        }


        // --- 2. MÉTODOS DE INSCRIPCIÓN ---

        // Nota: Dejé este método por si tu interfaz lo exige, pero hace lo mismo que InscribirUsuario
        public async Task<CompetenciaResponse> AgregarUsuarioACompetencia(Guid idCompetencia, Guid idUsuario)
        {
            return await InscribirUsuario(idCompetencia, idUsuario);
        }

        public async Task<CompetenciaResponse> InscribirUsuario(Guid idCompetencia, Guid idUsuario)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);

            if (competencia == null) throw new Exception("Competencia no encontrada.");

            // Armamos la "entrada" o "ticket" de inscripción
            var nuevaInscripcion = new Inscripcion
        {
                Id = Guid.NewGuid(), // Generamos un código único nuevo
                UsuarioId = idUsuario,
                ReferenciaId = idCompetencia,
                TipoInscripcion = Domain.Enums.TipoInscripcion.Competencia,
                Fecha = DateTime.Now
            };

            // Agregamos la inscripción a la lista de la competencia
            competencia.Inscripciones.Add(nuevaInscripcion);

            // Guardamos la competencia actualizada
            await _command.ModificarAsync(competencia);

            return Mapear(competencia);
        }

        public async Task<CompetenciaResponse> EliminarUsuarioDeCompetencia(Guid idCompetencia, Guid idUsuario)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);

            if (competencia == null) throw new Exception("Competencia no encontrada.");

            // Buscamos en la lista si existe una inscripción que coincida con este usuario
            var inscripcion = competencia.Inscripciones.FirstOrDefault(i => i.UsuarioId == idUsuario);

            // Si lo encontramos, lo borramos
            if (inscripcion != null)
        {
                competencia.Inscripciones.Remove(inscripcion);
                await _command.ModificarAsync(competencia);
            }

            return Mapear(competencia);
        }

        public async Task<CompetenciaResponse> ConsultarInscriptos(Guid idCompetencia)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);

            if (competencia == null) throw new Exception("Competencia no encontrada.");

            return Mapear(competencia);
        }


        // --- 3. MÉTODOS DE ACTIVIDADES ---

        public async Task<CompetenciaResponse> AgregarActividadACompetencia(Guid idCompetencia, Guid idActividad)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);
            if (competencia == null) throw new Exception("Competencia no encontrada.");

            // Lógica pendiente: competencia.ActividadesIds.Add(idActividad);

            await _command.ModificarAsync(competencia);
            return Mapear(competencia);
        }

        public async Task<CompetenciaResponse> EliminarActividadDeCompetencia(Guid idCompetencia, Guid idActividad)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);
            if (competencia == null) throw new Exception("Competencia no encontrada.");

            // Lógica pendiente: competencia.ActividadesIds.Remove(idActividad);

            await _command.ModificarAsync(competencia);
            return Mapear(competencia);
        }


        // --- 4. MÉTODOS DE TORNEO (FIXTURE) ---

        public async Task<CompetenciaResponse> GenerarFixture(Guid idCompetencia)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);

            if (competencia == null) throw new Exception("Competencia no encontrada.");

            if (competencia.Inscripciones.Count < 2)
        {
                throw new Exception("Se necesitan al menos 2 inscriptos para armar un fixture.");
        }

            var inscriptos = competencia.Inscripciones;

            // Este doble ciclo (for) cruza a todos contra todos.
            // Ejemplo: El jugador 0 juega contra el 1, 2 y 3. Luego el jugador 1 contra el 2 y 3.
            for (int i = 0; i < inscriptos.Count; i++)
            {
                for (int j = i + 1; j < inscriptos.Count; j++)
        {
                    var jugador1 = inscriptos[i].UsuarioId;
                    var jugador2 = inscriptos[j].UsuarioId;

                    // Acá se crearía el partido en la base de datos
                }
            }

            // Avisamos que el torneo ya arrancó
            competencia.Estado = EstadoCompetencia.EnCurso;
            await _command.ModificarAsync(competencia);

            return Mapear(competencia);
        }

        public async Task<CompetenciaResponse> ConsultarFixture(Guid idCompetencia)
        {
            var competencia = await _query.ObtenerPorIdAsync(idCompetencia);
            if (competencia == null) throw new Exception("Competencia no encontrada.");

            return Mapear(competencia);
        }


        // --- 5. EL TRADUCTOR PRIVADO (MAPPER) ---

        // Convierte la Entidad de la base de datos en un DTO (Response) para enviar a la pantalla web
        private CompetenciaResponse Mapear(Competencia competencia)
        {
            return new CompetenciaResponse
        {
                Id = competencia.Id,
                Nombre = competencia.Nombre,
                FechaInicio = competencia.FechaInicio,
                FechaFin = competencia.FechaFin,
                ReglamentoOficial = competencia.ReglamentoOficial,
                ReglamentoInterno = competencia.ReglamentoInterno
            };
        }

        public Task<IList<CompetenciaResponse>> IncribirUsario()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ConsultarInscriptos()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> GenerarFixture()
        {
            throw new NotImplementedException();
        }

        public Task<CompetenciaResponse> ConsultarFixture()
        {
            throw new NotImplementedException();
        }
    }
}
