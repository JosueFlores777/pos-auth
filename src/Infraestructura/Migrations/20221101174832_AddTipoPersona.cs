using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class AddTipoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPersonaId",
                table: "importador",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 11, 1, 11, 48, 32, 243, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.CreateIndex(
                name: "IX_importador_TipoPersonaId",
                table: "importador",
                column: "TipoPersonaId");

    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_importador_catalogo_TipoPersonaId",
                table: "importador");

            migrationBuilder.DropIndex(
                name: "IX_importador_TipoPersonaId",
                table: "importador");

            migrationBuilder.DropColumn(
                name: "TipoPersonaId",
                table: "importador");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 11, 1, 10, 20, 16, 230, DateTimeKind.Local).AddTicks(2012));
        }
    }
}
