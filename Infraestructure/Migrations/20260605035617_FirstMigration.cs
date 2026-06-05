using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("1f09a8b8-488b-44f0-8d7d-7c77c707c843"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("2ca0ae80-a025-4dde-b5a9-176ffb8731b7"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("db597ead-4733-4e5c-8775-69328d654974"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("47f915e4-4de7-4514-a7c6-a8e1cdfe7aa7"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("bb05ba9b-7675-4736-b1d5-0cf924507a61"));

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("6d21c6cd-b52c-4362-b12c-34c84f4435bf"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("c76e22b1-393a-456c-8619-c9e024805223"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("1dbaa27a-1bd1-48f7-adff-276e3e8739e8"), 1, 2, new Guid("6d21c6cd-b52c-4362-b12c-34c84f4435bf") },
                    { new Guid("217614b8-c084-48a1-ab6c-8bb4ffa718b5"), 1, 1, new Guid("6d21c6cd-b52c-4362-b12c-34c84f4435bf") },
                    { new Guid("9ae664f4-9ed2-4165-b050-781a2c54b27d"), 3, 3, new Guid("c76e22b1-393a-456c-8619-c9e024805223") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("1dbaa27a-1bd1-48f7-adff-276e3e8739e8"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("217614b8-c084-48a1-ab6c-8bb4ffa718b5"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("9ae664f4-9ed2-4165-b050-781a2c54b27d"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("6d21c6cd-b52c-4362-b12c-34c84f4435bf"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("c76e22b1-393a-456c-8619-c9e024805223"));

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("47f915e4-4de7-4514-a7c6-a8e1cdfe7aa7"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("bb05ba9b-7675-4736-b1d5-0cf924507a61"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("1f09a8b8-488b-44f0-8d7d-7c77c707c843"), 3, 3, new Guid("bb05ba9b-7675-4736-b1d5-0cf924507a61") },
                    { new Guid("2ca0ae80-a025-4dde-b5a9-176ffb8731b7"), 1, 2, new Guid("47f915e4-4de7-4514-a7c6-a8e1cdfe7aa7") },
                    { new Guid("db597ead-4733-4e5c-8775-69328d654974"), 1, 1, new Guid("47f915e4-4de7-4514-a7c6-a8e1cdfe7aa7") }
                });
        }
    }
}
