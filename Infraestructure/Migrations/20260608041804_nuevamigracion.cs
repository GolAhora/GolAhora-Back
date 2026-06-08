using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nuevamigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("726a6835-1b05-49d2-a59a-5d5ce57546b3"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("a278ce6d-3423-46f6-8edd-72980fc71b98"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("d936b341-3028-4589-b9be-2eec25960770"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("3d0176a6-8e9b-49fc-8025-6000fc9531f0"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("e92b3894-aea5-4259-81ea-5a02d8484ba4"));

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("7b0460e2-ca77-4371-962c-9c81303a9365"), 22, 2.0, "Futbol 11", 5000.0, 100 },
                    { new Guid("f6704f0d-bb2f-4344-964c-5573eee6d719"), 10, 2.0, "Futbol 5", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("42475654-4012-4d64-bef9-11c398def9db"), 1, 1, new Guid("f6704f0d-bb2f-4344-964c-5573eee6d719") },
                    { new Guid("86d99abd-7f6e-46b6-b6cb-ec4ec54c8026"), 3, 3, new Guid("7b0460e2-ca77-4371-962c-9c81303a9365") },
                    { new Guid("d8cddc93-af5e-4178-9c87-8daef9425243"), 1, 2, new Guid("f6704f0d-bb2f-4344-964c-5573eee6d719") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("42475654-4012-4d64-bef9-11c398def9db"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("86d99abd-7f6e-46b6-b6cb-ec4ec54c8026"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("d8cddc93-af5e-4178-9c87-8daef9425243"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("7b0460e2-ca77-4371-962c-9c81303a9365"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("f6704f0d-bb2f-4344-964c-5573eee6d719"));

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("3d0176a6-8e9b-49fc-8025-6000fc9531f0"), 10, 2.0, "Futbol 5", 5000.0, 100 },
                    { new Guid("e92b3894-aea5-4259-81ea-5a02d8484ba4"), 22, 2.0, "Futbol 11", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("726a6835-1b05-49d2-a59a-5d5ce57546b3"), 1, 1, new Guid("3d0176a6-8e9b-49fc-8025-6000fc9531f0") },
                    { new Guid("a278ce6d-3423-46f6-8edd-72980fc71b98"), 1, 2, new Guid("3d0176a6-8e9b-49fc-8025-6000fc9531f0") },
                    { new Guid("d936b341-3028-4589-b9be-2eec25960770"), 3, 3, new Guid("e92b3894-aea5-4259-81ea-5a02d8484ba4") }
                });
        }
    }
}
