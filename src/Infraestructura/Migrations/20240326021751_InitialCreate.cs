using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalogo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true),
                    IdPadre = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UsuarioCrea = table.Column<int>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: true),
                    UsuarioActualiza = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permiso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PermisoPadre = table.Column<int>(nullable: true),
                    EsMenu = table.Column<bool>(nullable: false),
                    Icono = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false),
                    Asignable = table.Column<bool>(nullable: false),
                    TieneHijos = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: true),
                    Asignable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    IdentificadorAcceso = table.Column<string>(maxLength: 100, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Contrasena = table.Column<string>(nullable: true),
                    CodigoTemporal = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: true),
                    CambiarContrasena = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: true),
                    FechaRestableceContrasena = table.Column<DateTime>(nullable: true),
                    TipoUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_catalogo_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "catalogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rolPermiso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(nullable: false),
                    PermisoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolPermiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolPermiso_permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolPermiso_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: true),
                    FechaEliminacion = table.Column<DateTime>(nullable: true),
                    PathFisico = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Indentificador = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivo_usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarioArea_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarioRegional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionalId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioRegional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarioRegional_catalogo_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "catalogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarioRegional_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarioRol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarioRol_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarioRol_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "importador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificadorId = table.Column<int>(nullable: false),
                    Identificador = table.Column<string>(maxLength: 50, nullable: true),
                    TipoPersonaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    NacionalidadId = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false),
                    MunicipioId = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(maxLength: 50, nullable: true),
                    ArchivoId = table.Column<int>(nullable: true),
                    TipoIngreso = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    CorreoEnviado = table.Column<bool>(nullable: false),
                    FechaEnvioCorreo = table.Column<DateTime>(nullable: true),
                    CorreoVerificado = table.Column<bool>(nullable: false),
                    FechaVerificacionCorreo = table.Column<DateTime>(nullable: true),
                    AccesoAprobado = table.Column<bool>(nullable: false),
                    FechaAprobacionAcceso = table.Column<DateTime>(nullable: true),
                    UsuarioGentionId = table.Column<int>(nullable: true),
                    TokenVerificacion = table.Column<string>(nullable: true),
                    MotivoRechazo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_importador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_importador_Archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "Archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_importador_catalogo_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "catalogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_importador_catalogo_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "catalogo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_importador_catalogo_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "catalogo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_importador_catalogo_TipoIdentificadorId",
                        column: x => x.TipoIdentificadorId,
                        principalTable: "catalogo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_importador_catalogo_TipoPersonaId",
                        column: x => x.TipoPersonaId,
                        principalTable: "catalogo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_importador_usuario_UsuarioGentionId",
                        column: x => x.UsuarioGentionId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "permiso",
                columns: new[] { "Id", "Asignable", "Codigo", "EsMenu", "Icono", "Nombre", "Orden", "PermisoPadre", "TieneHijos", "Url" },
                values: new object[,]
                {
                    { 1, true, "administracion", true, null, "ADMINISTRACIÓN", 1, null, true, "" },
                    { 20, true, "catalogo-editar", false, null, "Editar catalogo", 1, 17, false, "/catalogo/editar/:id" },
                    { 19, true, "catalogo-crear", false, null, "Crear catalogo", 1, 17, false, "/catalogo/crear" },
                    { 21, true, "catalogo-ver", false, null, "Ver catalogos", 1, 17, false, "/catalogo/ver/:id" },
                    { 17, true, "catalogos", true, "icon-book-open", "Catalogos", 1, 1, true, "/catalogos" },
                    { 18, true, "catalogo-listar", false, null, "Lista catalogos", 1, 17, false, "/catalogo" },
                    { 16, true, "gestionar-accesos-importador", false, null, "Gestión de accesos ", 0, 13, false, "/importadores/accesos" },
                    { 15, true, "listar-importadores", true, null, "Importadores", 0, 13, false, "/importadores" },
                    { 14, true, "gestionar-importador", false, null, "Gestionar importador", 1, 13, false, "/importadores/gestionar/:id" },
                    { 13, true, "importadores", true, "icon-people", "Importadores", 1, 1, true, "/importadores" },
                    { 12, true, "rol-ver", false, null, "Ver rol", 1, 8, false, "/rol/ver/:id" },
                    { 10, true, "rol-crear", false, null, "Crear rol", 1, 8, false, "/rol/crear" },
                    { 9, true, "rol-listar", false, null, "Lista roles", 2, 8, false, "/rol" },
                    { 8, true, "roles", true, "icon-key", "Rol", 1, 1, true, "/rol" },
                    { 7, true, "perfil-usuario", false, null, "Perfil de usuario", 1, 2, false, "/usuario/perfil/:id" },
                    { 6, true, "usuario-ver", false, null, "Ver usuario", 1, 2, false, "/usuario/ver/:id" },
                    { 5, true, "usuario-editar", false, null, "Editar usuario", 1, 2, false, "/usuario/editar/:id" },
                    { 4, true, "usuario-crear", false, null, "Crear usuario", 1, 2, false, "/usuario/crear" },
                    { 3, true, "usuario-listar", false, null, "Lista Usuarios", 1, 2, false, "/usuario" },
                    { 2, true, "usuarios", true, "icon-people", "Usuario", 1, 1, true, "/usuario" },
                    { 11, true, "rol-editar", false, null, "Editar rol", 1, 8, false, "/rol/editar/:id" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "Asignable", "Descripcion", "FechaActualizacion", "FechaCreacion", "Nombre" },
                values: new object[] { 1, false, "Rol para la administracion del sistema", null, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administración del Sistema" });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "Activo", "CambiarContrasena", "CodigoTemporal", "Contrasena", "DepartamentoId", "FechaActualizacion", "FechaRegistro", "FechaRestableceContrasena", "IdentificadorAcceso", "Nombre", "TipoUsuario" },
                values: new object[] { 1, true, false, null, "52A5D13A7FD60FFFFF425FA65C3830A165969AA983F06C365E48BAC0F8C75CD9", null, null, new DateTime(2024, 3, 25, 20, 17, 51, 43, DateTimeKind.Local).AddTicks(4102), null, "admin@gmail.com", "Administrador del sistema", "usuario-interno" });

            migrationBuilder.InsertData(
                table: "rolPermiso",
                columns: new[] { "Id", "PermisoId", "RolId" },
                values: new object[,]
                {
                    { 13, 1, 1 },
                    { 14, 3, 1 },
                    { 15, 4, 1 },
                    { 16, 5, 1 },
                    { 17, 7, 1 },
                    { 18, 9, 1 },
                    { 19, 10, 1 },
                    { 20, 11, 1 },
                    { 21, 12, 1 },
                    { 22, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_UsuarioID",
                table: "Archivo",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_importador_ArchivoId",
                table: "importador",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_importador_DepartamentoId",
                table: "importador",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_importador_MunicipioId",
                table: "importador",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_importador_NacionalidadId",
                table: "importador",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_importador_TipoIdentificadorId",
                table: "importador",
                column: "TipoIdentificadorId");

            migrationBuilder.CreateIndex(
                name: "IX_importador_TipoPersonaId",
                table: "importador",
                column: "TipoPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_importador_UsuarioGentionId",
                table: "importador",
                column: "UsuarioGentionId");

            migrationBuilder.CreateIndex(
                name: "IX_rolPermiso_PermisoId",
                table: "rolPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_rolPermiso_RolId",
                table: "rolPermiso",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_DepartamentoId",
                table: "usuario",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdentificadorAcceso",
                table: "usuario",
                column: "IdentificadorAcceso",
                unique: true,
                filter: "[IdentificadorAcceso] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioArea_AreaId",
                table: "usuarioArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioArea_UsuarioId",
                table: "usuarioArea",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRegional_RegionalId",
                table: "usuarioRegional",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRegional_UsuarioId",
                table: "usuarioRegional",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRol_RolId",
                table: "usuarioRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRol_UsuarioId",
                table: "usuarioRol",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "importador");

            migrationBuilder.DropTable(
                name: "rolPermiso");

            migrationBuilder.DropTable(
                name: "usuarioArea");

            migrationBuilder.DropTable(
                name: "usuarioRegional");

            migrationBuilder.DropTable(
                name: "usuarioRol");

            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "permiso");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "catalogo");
        }
    }
}
