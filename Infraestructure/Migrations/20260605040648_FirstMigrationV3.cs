using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0a25793a-35b5-4646-bbf8-c2e67b30d8f9"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("40e74fc4-f058-4403-907c-bb33062a67db"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("081ca5bc-133b-4bd2-b2d8-d024ff97ab02"), 1, 2, new Guid("0a25793a-35b5-4646-bbf8-c2e67b30d8f9") },
                    { new Guid("13083bc7-ac9b-4b67-88f5-58fe37808eeb"), 3, 3, new Guid("40e74fc4-f058-4403-907c-bb33062a67db") },
                    { new Guid("74eeb1c3-f642-4f93-bd11-d40485490ce3"), 1, 1, new Guid("0a25793a-35b5-4646-bbf8-c2e67b30d8f9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("081ca5bc-133b-4bd2-b2d8-d024ff97ab02"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("13083bc7-ac9b-4b67-88f5-58fe37808eeb"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("74eeb1c3-f642-4f93-bd11-d40485490ce3"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("0a25793a-35b5-4646-bbf8-c2e67b30d8f9"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("40e74fc4-f058-4403-907c-bb33062a67db"));

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
    }
}
