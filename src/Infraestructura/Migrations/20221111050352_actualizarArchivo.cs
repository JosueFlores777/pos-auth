using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class actualizarArchivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Archivo",
                newName: "UsuarioID");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Archivo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indentificador",
                table: "Archivo",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 11, 10, 23, 3, 51, 874, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_UsuarioID",
                table: "Archivo",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivo_usuario_UsuarioID",
                table: "Archivo",
                column: "UsuarioID",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivo_usuario_UsuarioID",
                table: "Archivo");

            migrationBuilder.DropIndex(
                name: "IX_Archivo_UsuarioID",
                table: "Archivo");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Archivo");

            migrationBuilder.DropColumn(
                name: "Indentificador",
                table: "Archivo");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Archivo",
                newName: "UsuarioId");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 11, 1, 14, 47, 14, 554, DateTimeKind.Local).AddTicks(9068));
        }
    }
}
