using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class AddTipoIdentificador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoIdentificadorId",
                table: "importador",
                nullable: false,
                defaultValue: 0);

          
            migrationBuilder.CreateIndex(
                name: "IX_importador_TipoIdentificadorId",
                table: "importador",
                column: "TipoIdentificadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_importador_catalogo_TipoIdentificadorId",
                table: "importador");

            migrationBuilder.DropIndex(
                name: "IX_importador_TipoIdentificadorId",
                table: "importador");

            migrationBuilder.DropColumn(
                name: "TipoIdentificadorId",
                table: "importador");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 10, 29, 12, 48, 0, 292, DateTimeKind.Local).AddTicks(1617));
        }
    }
}
