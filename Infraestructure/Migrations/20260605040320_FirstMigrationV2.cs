using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("7dd24a07-6150-4e00-8c7c-44177479b5f5"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("eedb1cc3-fff8-4e0c-b18e-0717d425d6a7"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("bb4e7db9-101d-44ca-af0d-1c7becb9544a"), 1, 2, new Guid("7dd24a07-6150-4e00-8c7c-44177479b5f5") },
                    { new Guid("db995494-777b-4fe4-84ba-8f069d4e6eac"), 3, 3, new Guid("eedb1cc3-fff8-4e0c-b18e-0717d425d6a7") },
                    { new Guid("ff95bffa-5d0b-4293-8e28-8a44714adda2"), 1, 1, new Guid("7dd24a07-6150-4e00-8c7c-44177479b5f5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("bb4e7db9-101d-44ca-af0d-1c7becb9544a"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("db995494-777b-4fe4-84ba-8f069d4e6eac"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("ff95bffa-5d0b-4293-8e28-8a44714adda2"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("7dd24a07-6150-4e00-8c7c-44177479b5f5"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("eedb1cc3-fff8-4e0c-b18e-0717d425d6a7"));

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
    }
}
