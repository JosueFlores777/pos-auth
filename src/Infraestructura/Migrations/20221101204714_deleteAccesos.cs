using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class deleteAccesos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportadorAccesos");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 11, 1, 14, 47, 14, 554, DateTimeKind.Local).AddTicks(9068));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportadorAccesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccesoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImportardorId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreo = table.Column<int>(type: "int", nullable: false),
                    UsuarioModifica = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportadorAccesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportadorAccesos_rol_AccesoId",
                        column: x => x.AccesoId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportadorAccesos_importador_ImportardorId",
                        column: x => x.ImportardorId,
                        principalTable: "importador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 11, 1, 11, 48, 32, 243, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.CreateIndex(
                name: "IX_ImportadorAccesos_AccesoId",
                table: "ImportadorAccesos",
                column: "AccesoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportadorAccesos_ImportardorId",
                table: "ImportadorAccesos",
                column: "ImportardorId");
        }
    }
}
