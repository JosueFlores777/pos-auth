using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class FixCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModeloId",
                table: "cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 3, 28, 16, 35, 17, 250, DateTimeKind.Local).AddTicks(3573));

            migrationBuilder.CreateIndex(
                name: "IX_cliente_MarcaId",
                table: "cliente",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_ModeloId",
                table: "cliente",
                column: "ModeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_catalogo_MarcaId",
                table: "cliente",
                column: "MarcaId",
                principalTable: "catalogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_catalogo_ModeloId",
                table: "cliente",
                column: "ModeloId",
                principalTable: "catalogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_catalogo_MarcaId",
                table: "cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_cliente_catalogo_ModeloId",
                table: "cliente");

            migrationBuilder.DropIndex(
                name: "IX_cliente_MarcaId",
                table: "cliente");

            migrationBuilder.DropIndex(
                name: "IX_cliente_ModeloId",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "cliente");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 3, 25, 20, 46, 10, 606, DateTimeKind.Local).AddTicks(1145));
        }
    }
}
