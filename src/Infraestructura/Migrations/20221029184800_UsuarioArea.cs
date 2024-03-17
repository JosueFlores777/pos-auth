using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class UsuarioArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarioArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarioArea_catalogo_AreaId",
                        column: x => x.AreaId,
                        principalTable: "catalogo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_usuarioArea_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

          


            migrationBuilder.CreateIndex(
                name: "IX_usuarioArea_AreaId",
                table: "usuarioArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioArea_UsuarioId",
                table: "usuarioArea",
                column: "UsuarioId");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarioArea");

            migrationBuilder.DropTable(
                name: "usuarioRegional");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 6, 29, 17, 40, 26, 575, DateTimeKind.Local).AddTicks(9934));
        }
    }
}
