﻿// <auto-generated />
using System;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructura.Migrations
{
    [DbContext(typeof(AutenticationContext))]
    partial class AutenticationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Models.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Indentificador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathFisico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Archivo");
                });

            modelBuilder.Entity("Dominio.Models.Catalogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdPadre")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioActualiza")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioCrea")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("catalogo");
                });

            modelBuilder.Entity("Dominio.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AccesoAprobado")
                        .HasColumnType("bit");

                    b.Property<int?>("ArchivoId")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("CorreoEnviado")
                        .HasColumnType("bit");

                    b.Property<bool>("CorreoVerificado")
                        .HasColumnType("bit");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaAprobacionAcceso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEnvioCorreo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVerificacionCorreo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificador")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("MotivoRechazo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoIdentificadorId")
                        .HasColumnType("int");

                    b.Property<string>("TipoIngreso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPersonaId")
                        .HasColumnType("int");

                    b.Property<string>("TokenVerificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioGentionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("NacionalidadId");

                    b.HasIndex("TipoIdentificadorId");

                    b.HasIndex("TipoPersonaId");

                    b.HasIndex("UsuarioGentionId");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Dominio.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Asignable")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsMenu")
                        .HasColumnType("bit");

                    b.Property<string>("Icono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<int?>("PermisoPadre")
                        .HasColumnType("int");

                    b.Property<bool>("TieneHijos")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("permiso");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Asignable = true,
                            Codigo = "administracion",
                            EsMenu = true,
                            Nombre = "ADMINISTRACIÓN",
                            Orden = 1,
                            TieneHijos = true,
                            Url = ""
                        },
                        new
                        {
                            Id = 2,
                            Asignable = true,
                            Codigo = "usuarios",
                            EsMenu = true,
                            Icono = "icon-people",
                            Nombre = "Usuario",
                            Orden = 1,
                            PermisoPadre = 1,
                            TieneHijos = true,
                            Url = "/usuario"
                        },
                        new
                        {
                            Id = 3,
                            Asignable = true,
                            Codigo = "usuario-listar",
                            EsMenu = false,
                            Nombre = "Lista Usuarios",
                            Orden = 1,
                            PermisoPadre = 2,
                            TieneHijos = false,
                            Url = "/usuario"
                        },
                        new
                        {
                            Id = 4,
                            Asignable = true,
                            Codigo = "usuario-crear",
                            EsMenu = false,
                            Nombre = "Crear usuario",
                            Orden = 1,
                            PermisoPadre = 2,
                            TieneHijos = false,
                            Url = "/usuario/crear"
                        },
                        new
                        {
                            Id = 5,
                            Asignable = true,
                            Codigo = "usuario-editar",
                            EsMenu = false,
                            Nombre = "Editar usuario",
                            Orden = 1,
                            PermisoPadre = 2,
                            TieneHijos = false,
                            Url = "/usuario/editar/:id"
                        },
                        new
                        {
                            Id = 6,
                            Asignable = true,
                            Codigo = "usuario-ver",
                            EsMenu = false,
                            Nombre = "Ver usuario",
                            Orden = 1,
                            PermisoPadre = 2,
                            TieneHijos = false,
                            Url = "/usuario/ver/:id"
                        },
                        new
                        {
                            Id = 7,
                            Asignable = true,
                            Codigo = "perfil-usuario",
                            EsMenu = false,
                            Nombre = "Perfil de usuario",
                            Orden = 1,
                            PermisoPadre = 2,
                            TieneHijos = false,
                            Url = "/usuario/perfil/:id"
                        },
                        new
                        {
                            Id = 8,
                            Asignable = true,
                            Codigo = "roles",
                            EsMenu = true,
                            Icono = "icon-key",
                            Nombre = "Rol",
                            Orden = 1,
                            PermisoPadre = 1,
                            TieneHijos = true,
                            Url = "/rol"
                        },
                        new
                        {
                            Id = 9,
                            Asignable = true,
                            Codigo = "rol-listar",
                            EsMenu = false,
                            Nombre = "Lista roles",
                            Orden = 2,
                            PermisoPadre = 8,
                            TieneHijos = false,
                            Url = "/rol"
                        },
                        new
                        {
                            Id = 10,
                            Asignable = true,
                            Codigo = "rol-crear",
                            EsMenu = false,
                            Nombre = "Crear rol",
                            Orden = 1,
                            PermisoPadre = 8,
                            TieneHijos = false,
                            Url = "/rol/crear"
                        },
                        new
                        {
                            Id = 11,
                            Asignable = true,
                            Codigo = "rol-editar",
                            EsMenu = false,
                            Nombre = "Editar rol",
                            Orden = 1,
                            PermisoPadre = 8,
                            TieneHijos = false,
                            Url = "/rol/editar/:id"
                        },
                        new
                        {
                            Id = 12,
                            Asignable = true,
                            Codigo = "rol-ver",
                            EsMenu = false,
                            Nombre = "Ver rol",
                            Orden = 1,
                            PermisoPadre = 8,
                            TieneHijos = false,
                            Url = "/rol/ver/:id"
                        },
                        new
                        {
                            Id = 13,
                            Asignable = true,
                            Codigo = "importadores",
                            EsMenu = true,
                            Icono = "icon-people",
                            Nombre = "Importadores",
                            Orden = 1,
                            PermisoPadre = 1,
                            TieneHijos = true,
                            Url = "/importadores"
                        },
                        new
                        {
                            Id = 14,
                            Asignable = true,
                            Codigo = "gestionar-importador",
                            EsMenu = false,
                            Nombre = "Gestionar importador",
                            Orden = 1,
                            PermisoPadre = 13,
                            TieneHijos = false,
                            Url = "/importadores/gestionar/:id"
                        },
                        new
                        {
                            Id = 15,
                            Asignable = true,
                            Codigo = "listar-importadores",
                            EsMenu = true,
                            Nombre = "Importadores",
                            Orden = 0,
                            PermisoPadre = 13,
                            TieneHijos = false,
                            Url = "/importadores"
                        },
                        new
                        {
                            Id = 16,
                            Asignable = true,
                            Codigo = "gestionar-accesos-importador",
                            EsMenu = false,
                            Nombre = "Gestión de accesos ",
                            Orden = 0,
                            PermisoPadre = 13,
                            TieneHijos = false,
                            Url = "/importadores/accesos"
                        },
                        new
                        {
                            Id = 18,
                            Asignable = true,
                            Codigo = "catalogo-listar",
                            EsMenu = false,
                            Nombre = "Lista catalogos",
                            Orden = 1,
                            PermisoPadre = 17,
                            TieneHijos = false,
                            Url = "/catalogo"
                        },
                        new
                        {
                            Id = 17,
                            Asignable = true,
                            Codigo = "catalogos",
                            EsMenu = true,
                            Icono = "icon-book-open",
                            Nombre = "Catalogos",
                            Orden = 1,
                            PermisoPadre = 1,
                            TieneHijos = true,
                            Url = "/catalogos"
                        },
                        new
                        {
                            Id = 21,
                            Asignable = true,
                            Codigo = "catalogo-ver",
                            EsMenu = false,
                            Nombre = "Ver catalogos",
                            Orden = 1,
                            PermisoPadre = 17,
                            TieneHijos = false,
                            Url = "/catalogo/ver/:id"
                        },
                        new
                        {
                            Id = 19,
                            Asignable = true,
                            Codigo = "catalogo-crear",
                            EsMenu = false,
                            Nombre = "Crear catalogo",
                            Orden = 1,
                            PermisoPadre = 17,
                            TieneHijos = false,
                            Url = "/catalogo/crear"
                        },
                        new
                        {
                            Id = 20,
                            Asignable = true,
                            Codigo = "catalogo-editar",
                            EsMenu = false,
                            Nombre = "Editar catalogo",
                            Orden = 1,
                            PermisoPadre = 17,
                            TieneHijos = false,
                            Url = "/catalogo/editar/:id"
                        });
                });

            modelBuilder.Entity("Dominio.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Asignable")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("rol");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Asignable = false,
                            Descripcion = "Rol para la administracion del sistema",
                            FechaCreacion = new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Administración del Sistema"
                        });
                });

            modelBuilder.Entity("Dominio.Models.RolPermiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermisoId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermisoId");

                    b.HasIndex("RolId");

                    b.ToTable("rolPermiso");

                    b.HasData(
                        new
                        {
                            Id = 13,
                            PermisoId = 1,
                            RolId = 1
                        },
                        new
                        {
                            Id = 14,
                            PermisoId = 3,
                            RolId = 1
                        },
                        new
                        {
                            Id = 15,
                            PermisoId = 4,
                            RolId = 1
                        },
                        new
                        {
                            Id = 16,
                            PermisoId = 5,
                            RolId = 1
                        },
                        new
                        {
                            Id = 17,
                            PermisoId = 7,
                            RolId = 1
                        },
                        new
                        {
                            Id = 18,
                            PermisoId = 9,
                            RolId = 1
                        },
                        new
                        {
                            Id = 19,
                            PermisoId = 10,
                            RolId = 1
                        },
                        new
                        {
                            Id = 20,
                            PermisoId = 11,
                            RolId = 1
                        },
                        new
                        {
                            Id = 21,
                            PermisoId = 12,
                            RolId = 1
                        },
                        new
                        {
                            Id = 22,
                            PermisoId = 2,
                            RolId = 1
                        });
                });

            modelBuilder.Entity("Dominio.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<bool>("CambiarContrasena")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoTemporal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRestableceContrasena")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentificadorAcceso")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("IdentificadorAcceso")
                        .IsUnique()
                        .HasFilter("[IdentificadorAcceso] IS NOT NULL");

                    b.ToTable("usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            CambiarContrasena = false,
                            Contrasena = "52A5D13A7FD60FFFFF425FA65C3830A165969AA983F06C365E48BAC0F8C75CD9",
                            FechaRegistro = new DateTime(2024, 3, 29, 10, 54, 37, 639, DateTimeKind.Local).AddTicks(4263),
                            IdentificadorAcceso = "admin@gmail.com",
                            Nombre = "Administrador del sistema",
                            TipoUsuario = "usuario-interno"
                        });
                });

            modelBuilder.Entity("Dominio.Models.UsuarioArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("usuarioArea");
                });

            modelBuilder.Entity("Dominio.Models.UsuarioRegional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegionalId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionalId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("usuarioRegional");
                });

            modelBuilder.Entity("Dominio.Models.UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("usuarioRol");
                });

            modelBuilder.Entity("Dominio.Models.Archivo", b =>
                {
                    b.HasOne("Dominio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("Dominio.Models.Cliente", b =>
                {
                    b.HasOne("Dominio.Models.Archivo", "Archivo")
                        .WithMany()
                        .HasForeignKey("ArchivoId");

                    b.HasOne("Dominio.Models.Catalogo", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Catalogo", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Catalogo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Catalogo", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Catalogo", "Nacionalidad")
                        .WithMany()
                        .HasForeignKey("NacionalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Catalogo", "TipoIdentificador")
                        .WithMany()
                        .HasForeignKey("TipoIdentificadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Catalogo", "TipoPersona")
                        .WithMany()
                        .HasForeignKey("TipoPersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Usuario", "UsuarioGention")
                        .WithMany()
                        .HasForeignKey("UsuarioGentionId");
                });

            modelBuilder.Entity("Dominio.Models.RolPermiso", b =>
                {
                    b.HasOne("Dominio.Models.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Rol", "Rol")
                        .WithMany("Permisos")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Models.Usuario", b =>
                {
                    b.HasOne("Dominio.Models.Catalogo", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId");
                });

            modelBuilder.Entity("Dominio.Models.UsuarioArea", b =>
                {
                    b.HasOne("Dominio.Models.Catalogo", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Usuario", "Usuario")
                        .WithMany("UsuarioArea")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Models.UsuarioRegional", b =>
                {
                    b.HasOne("Dominio.Models.Catalogo", "Regional")
                        .WithMany()
                        .HasForeignKey("RegionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Usuario", "Usuario")
                        .WithMany("UsuarioRegional")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Models.UsuarioRol", b =>
                {
                    b.HasOne("Dominio.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.Usuario", "Usuario")
                        .WithMany("Roles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
