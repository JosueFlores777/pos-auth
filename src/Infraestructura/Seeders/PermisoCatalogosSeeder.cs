using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Seeders
{
    public static class PermisoCatalogosSeeder
    {



        public static void Seed(ModelBuilder builder)
        {
            var catalogoRoot = new Permiso { PermisoPadre= Permiso.idPermisoAdministracion, Id = 17, Codigo = "catalogos", EsMenu = true, Nombre = "Catalogos", Orden = 1, Url = "/catalogos", Icono = "icon-book-open", Asignable=true, TieneHijos = true };
            var catalogoLista = new Permiso { PermisoPadre = catalogoRoot.Id, Id = 21, Codigo = "catalogo-ver", EsMenu = false, Nombre = "Ver catalogos", Orden = 1, Url = "/catalogo/ver/:id", Asignable = true, TieneHijos = false };
            var catalogoVer= new Permiso { PermisoPadre= catalogoRoot.Id, Id =18, Codigo = "catalogo-listar", EsMenu = false, Nombre = "Lista catalogos", Orden = 1, Url = "/catalogo", Asignable = true, TieneHijos = false };
            var catalogocrear = new Permiso { PermisoPadre = catalogoRoot.Id, Id = 19, Codigo = "catalogo-crear", EsMenu = false, Nombre = "Crear catalogo", Orden = 1, Url = "/catalogo/crear", Asignable = true, TieneHijos = false };
            var catalogoEditar = new Permiso { PermisoPadre = catalogoRoot.Id, Id = 20, Codigo = "catalogo-editar", EsMenu = false, Nombre = "Editar catalogo", Orden = 1, Url = "/catalogo/editar/:id", Asignable = true, TieneHijos = false };
            builder.Entity<Permiso>().HasData(catalogoVer);
            builder.Entity<Permiso>().HasData(catalogoRoot);
            builder.Entity<Permiso>().HasData(catalogoLista);
            builder.Entity<Permiso>().HasData(catalogocrear);
            builder.Entity<Permiso>().HasData(catalogoEditar);

        }

    }
}
