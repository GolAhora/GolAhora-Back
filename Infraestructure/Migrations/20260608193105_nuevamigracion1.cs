using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nuevamigracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Persona",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Edad",
                table: "Persona",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Persona",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "TipoCancha",
                columns: new[] { "Id", "Capacidad", "DuracionMax", "Nombre", "PrecioBaseHora", "Superficie" },
                values: new object[,]
                {
                    { new Guid("2520a325-dc96-4f48-97ae-04bce529cf94"), 22, 2.0, "Futbol 11", 5000.0, 100 },
                    { new Guid("704aab69-1bf0-406c-bae7-3dd3fd584e9c"), 10, 2.0, "Futbol 5", 5000.0, 100 }
                });

            migrationBuilder.InsertData(
                table: "Cancha",
                columns: new[] { "Id", "Estado", "Numero", "TipoCanchaId" },
                values: new object[,]
                {
                    { new Guid("0cf136d1-0cb3-4bcf-a60e-ae8435941107"), 3, 3, new Guid("2520a325-dc96-4f48-97ae-04bce529cf94") },
                    { new Guid("408dd3d6-a869-4895-97cc-cbb9fa8e2dee"), 1, 2, new Guid("704aab69-1bf0-406c-bae7-3dd3fd584e9c") },
                    { new Guid("71d31f25-f123-4d5f-b52a-09aeb043811f"), 1, 1, new Guid("704aab69-1bf0-406c-bae7-3dd3fd584e9c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("0cf136d1-0cb3-4bcf-a60e-ae8435941107"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("408dd3d6-a869-4895-97cc-cbb9fa8e2dee"));

            migrationBuilder.DeleteData(
                table: "Cancha",
                keyColumn: "Id",
                keyValue: new Guid("71d31f25-f123-4d5f-b52a-09aeb043811f"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("2520a325-dc96-4f48-97ae-04bce529cf94"));

            migrationBuilder.DeleteData(
                table: "TipoCancha",
                keyColumn: "Id",
                keyValue: new Guid("704aab69-1bf0-406c-bae7-3dd3fd584e9c"));

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Persona",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Edad",
                table: "Persona",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Persona",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
    }
}
