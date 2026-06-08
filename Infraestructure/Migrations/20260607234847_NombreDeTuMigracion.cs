using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Actividad_ActividadId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Persona_UsuarioId",
                table: "Inscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Inscripcion_ActividadId",
                table: "Inscripcion");

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("21bbc35e-531b-47cf-a3fb-0ec1c492a3b8"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("7d07e8a4-702c-4ec1-b964-825e19e6f882"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("b454091c-9f0d-44a9-9a0b-97fc1efd3ddb"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("02b1c362-9287-4962-b62b-b26204792f97"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("120a32e0-cca8-49a8-bbaa-26be18b3b081"));

            migrationBuilder.DropColumn(
                name: "ActividadId",
                table: "Inscripcion");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Actividad",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EntrenadorId",
                table: "Actividad",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfesorId",
                table: "Actividad",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoReferencia",
                table: "Actividad",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("66601942-6d1e-4d44-ade9-6cf5215e3af3"), 22, 2.0, "Futbol 11", 5000.0, 100 },
                    { new Guid("d3c1c19e-61f8-433c-a565-65d8965c1375"), 10, 2.0, "Futbol 5", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("2b06a773-fd76-4347-ba9e-2664f884addb"), 3, 3, new Guid("66601942-6d1e-4d44-ade9-6cf5215e3af3") },
                    { new Guid("af456ce5-6ca1-4808-bae8-1be2e6df8b6b"), 1, 1, new Guid("d3c1c19e-61f8-433c-a565-65d8965c1375") },
                    { new Guid("dc31ae8e-7584-4bab-8b09-837ef9d072b3"), 1, 2, new Guid("d3c1c19e-61f8-433c-a565-65d8965c1375") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_ReferenciaId",
                table: "Inscripcion",
                column: "ReferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_EntrenadorId",
                table: "Actividad",
                column: "EntrenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ProfesorId",
                table: "Actividad",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividad_Persona_EntrenadorId",
                table: "Actividad",
                column: "EntrenadorId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividad_Persona_ProfesorId",
                table: "Actividad",
                column: "ProfesorId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Actividad_ReferenciaId",
                table: "Inscripcion",
                column: "ReferenciaId",
                principalTable: "Actividad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Persona_UsuarioId",
                table: "Inscripcion",
                column: "UsuarioId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividad_Persona_EntrenadorId",
                table: "Actividad");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividad_Persona_ProfesorId",
                table: "Actividad");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Actividad_ReferenciaId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Persona_UsuarioId",
                table: "Inscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Inscripcion_ReferenciaId",
                table: "Inscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Actividad_EntrenadorId",
                table: "Actividad");

            migrationBuilder.DropIndex(
                name: "IX_Actividad_ProfesorId",
                table: "Actividad");

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("2b06a773-fd76-4347-ba9e-2664f884addb"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("af456ce5-6ca1-4808-bae8-1be2e6df8b6b"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("dc31ae8e-7584-4bab-8b09-837ef9d072b3"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("66601942-6d1e-4d44-ade9-6cf5215e3af3"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("d3c1c19e-61f8-433c-a565-65d8965c1375"));

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Actividad");

            migrationBuilder.DropColumn(
                name: "EntrenadorId",
                table: "Actividad");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Actividad");

            migrationBuilder.DropColumn(
                name: "TipoReferencia",
                table: "Actividad");

            migrationBuilder.AddColumn<Guid>(
                name: "ActividadId",
                table: "Inscripcion",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("02b1c362-9287-4962-b62b-b26204792f97"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("120a32e0-cca8-49a8-bbaa-26be18b3b081"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("21bbc35e-531b-47cf-a3fb-0ec1c492a3b8"), 1, 2, new Guid("02b1c362-9287-4962-b62b-b26204792f97") },
                    { new Guid("7d07e8a4-702c-4ec1-b964-825e19e6f882"), 3, 3, new Guid("120a32e0-cca8-49a8-bbaa-26be18b3b081") },
                    { new Guid("b454091c-9f0d-44a9-9a0b-97fc1efd3ddb"), 1, 1, new Guid("02b1c362-9287-4962-b62b-b26204792f97") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_ActividadId",
                table: "Inscripcion",
                column: "ActividadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Actividad_ActividadId",
                table: "Inscripcion",
                column: "ActividadId",
                principalTable: "Actividad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Persona_UsuarioId",
                table: "Inscripcion",
                column: "UsuarioId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
