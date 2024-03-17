using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Seeders
{
    public static class PermisoSeeder
    {

        private static int Id = 0;


        public static void Seed(ModelBuilder builder)
        {
            var permisoModuloAutenticacion = new Permiso { Id = getId(), Codigo = "administracion", EsMenu = true, Nombre = "ADMINISTRACIÓN", Orden = 1, Url = "", Asignable=true, TieneHijos = true };
            var usuarios = new Permiso { PermisoPadre= permisoModuloAutenticacion.Id ,Id = getId(), Codigo = "usuarios", EsMenu = true, Nombre = "Usuario", Orden = 1, Url = "/usuario", Icono = "icon-people", Asignable=true, TieneHijos = true };
           
            var permisoUsuario = new Permiso { PermisoPadre= usuarios.Id, Id = getId(), Codigo = "usuario-listar", EsMenu = false, Nombre = "Lista Usuarios", Orden = 1, Url = "/usuario", Asignable = true, TieneHijos = false };
            var permisoUsuarioCrear = new Permiso { PermisoPadre = usuarios.Id, Id = getId(), Codigo = "usuario-crear", EsMenu = false, Nombre = "Crear usuario", Orden = 1, Url = "/usuario/crear", Asignable = true, TieneHijos = false };
            var usuarioeditar = new Permiso { PermisoPadre = usuarios.Id, Id = getId(), Codigo = "usuario-editar", EsMenu = false, Nombre = "Editar usuario", Orden = 1, Url = "/usuario/editar/:id", Asignable = true, TieneHijos = false };
            var usuarioVer = new Permiso { PermisoPadre = usuarios.Id, Id = getId(), Codigo = "usuario-ver", EsMenu = false, Nombre = "Ver usuario", Orden = 1, Url = "/usuario/ver/:id", Asignable = true, TieneHijos = false };

            var permisoPerfilUsuario = new Permiso { Id = getId(), PermisoPadre = usuarios.Id, Codigo = "perfil-usuario", EsMenu = false, Nombre = "Perfil de usuario", Orden = 1, Url = "/usuario/perfil/:id", Asignable = true, TieneHijos = false };

            var roles = new Permiso { PermisoPadre = permisoModuloAutenticacion.Id , Id = getId(), Codigo = "roles", EsMenu = true, Nombre = "Rol", Orden = 1, Url = "/rol", Icono = "icon-key", Asignable = true, TieneHijos = true };
           
            var permisoRol = new Permiso { PermisoPadre = roles.Id, Id = getId(), Codigo = "rol-listar", EsMenu = false, Nombre = "Lista roles", Orden = permisoUsuario.Orden + 1, Url = "/rol", Asignable = true, TieneHijos = false };
            var permisoRolCrear = new Permiso { PermisoPadre = roles.Id, Id = getId(), Codigo = "rol-crear", EsMenu = false, Nombre = "Crear rol", Orden = 1, Url = "/rol/crear", Asignable = true, TieneHijos = false };
            var editarRol = new Permiso { PermisoPadre = roles.Id, Id = getId(), Codigo = "rol-editar", EsMenu = false, Nombre = "Editar rol", Orden = 1, Url = "/rol/editar/:id", Asignable = true, TieneHijos = false };
            var verRol = new Permiso { PermisoPadre = roles.Id, Id = getId(), Codigo = "rol-ver", EsMenu = false, Nombre = "Ver rol", Orden = 1, Url = "/rol/ver/:id", Asignable = true, TieneHijos = false };


            
            var rolAdminitracionSistema = new Rol { Id = Rol.IdRolAdministracionSistema, Asignable = false, Descripcion = "Rol para la administracion del sistema", FechaCreacion = new DateTime(2020, 4, 27), Nombre = "Administración del Sistema" };
            var rolPermisoAdmin = new RolPermiso { Id = getId2(), PermisoId = permisoModuloAutenticacion.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin2 = new RolPermiso { Id = getId2(), PermisoId = permisoUsuario.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin3 = new RolPermiso { Id = getId2(), PermisoId = permisoUsuarioCrear.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin4 = new RolPermiso { Id = getId2(), PermisoId = usuarioeditar.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin5 = new RolPermiso { Id = getId2(), PermisoId = permisoPerfilUsuario.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin6 = new RolPermiso { Id = getId2(), PermisoId = permisoRol.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin7 = new RolPermiso { Id = getId2(), PermisoId = permisoRolCrear.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin8 = new RolPermiso { Id = getId2(), PermisoId = editarRol.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin9 = new RolPermiso { Id = getId2(), PermisoId = verRol.Id, RolId = rolAdminitracionSistema.Id };
            var rolPermisoAdmin10 = new RolPermiso { Id = getId2(), PermisoId = usuarios.Id, RolId = rolAdminitracionSistema.Id };



            builder.Entity<Rol>().HasData(rolAdminitracionSistema);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin2);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin3);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin4);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin5);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin6);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin7);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin8);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin9);
            builder.Entity<RolPermiso>().HasData(rolPermisoAdmin10);

            builder.Entity<Permiso>().HasData(permisoModuloAutenticacion);
            builder.Entity<Permiso>().HasData(usuarios);
            builder.Entity<Permiso>().HasData(permisoUsuario);
            builder.Entity<Permiso>().HasData(permisoUsuarioCrear);
            builder.Entity<Permiso>().HasData(usuarioeditar);
            builder.Entity<Permiso>().HasData(usuarioVer);
            builder.Entity<Permiso>().HasData(permisoPerfilUsuario);

            builder.Entity<Permiso>().HasData(roles);
            builder.Entity<Permiso>().HasData(permisoRol);
            builder.Entity<Permiso>().HasData(permisoRolCrear);
            builder.Entity<Permiso>().HasData(editarRol);
            builder.Entity<Permiso>().HasData(verRol);
        }

        private static int getId()
        {
            Id = Id + 1;
            return Id;
        }
        private static int getId2()
        {
            Id = Id + 1;
            return Id;
        }
    }
}
