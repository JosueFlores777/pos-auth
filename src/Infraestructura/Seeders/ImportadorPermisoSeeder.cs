using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Seeders
{
    public class ImportadorPermisoSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var permiso = new Permiso { PermisoPadre = Permiso.idPermisoAdministracion, Id = 13, Codigo = "importadores", EsMenu = true, Nombre = "Importadores", Orden = 1, Url = "/importadores", Icono = "icon-people", Asignable = true, TieneHijos = true };
            var permisoInvitarUsuario = new Permiso { PermisoPadre = permiso.Id, Id = 14, Codigo = "gestionar-importador", EsMenu = false, Nombre = "Gestionar importador", Orden = 1, Url = "/importadores/gestionar/:id", Asignable = true, TieneHijos = false };
            var listarPermiso = new Permiso { PermisoPadre = permiso.Id, Id = 15, Codigo = "listar-importadores", EsMenu = true, Nombre = "Importadores", Url = "/importadores", Asignable = true, TieneHijos = false };
            var gestionarAccesos = new Permiso { PermisoPadre = permiso.Id, Id = 16, Codigo = "gestionar-accesos-importador", EsMenu = false, Nombre = "Gestión de accesos ", Url = "/importadores/accesos", Asignable = true, TieneHijos = false };


            builder.Entity<Permiso>().HasData(permiso);
            builder.Entity<Permiso>().HasData(permisoInvitarUsuario);

            builder.Entity<Permiso>().HasData(listarPermiso);

            builder.Entity<Permiso>().HasData(gestionarAccesos);

        }
    }
}
