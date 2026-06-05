using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("07b1c93c-8de0-44fe-b4a8-f6e457e578b6"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("db87cde9-1127-4d33-9e6f-75dc038e2fa7"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("209b8786-0c92-490f-b08d-9b8a3447125c"), 3, 3, new Guid("db87cde9-1127-4d33-9e6f-75dc038e2fa7") },
                    { new Guid("8b75342d-0383-4373-b491-62d33d147a85"), 1, 1, new Guid("07b1c93c-8de0-44fe-b4a8-f6e457e578b6") },
                    { new Guid("8f1b01b8-f209-479f-adb6-03b13fafff37"), 1, 2, new Guid("07b1c93c-8de0-44fe-b4a8-f6e457e578b6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("209b8786-0c92-490f-b08d-9b8a3447125c"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("8b75342d-0383-4373-b491-62d33d147a85"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("8f1b01b8-f209-479f-adb6-03b13fafff37"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("07b1c93c-8de0-44fe-b4a8-f6e457e578b6"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("db87cde9-1127-4d33-9e6f-75dc038e2fa7"));

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
    }
}
