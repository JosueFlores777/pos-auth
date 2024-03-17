using Aplicacion.CommandHandlers;
using Aplicacion.Commands;
using Aplicacion.Dtos;
using Aplicacion.Services.ConsultaPermiso;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Test.ComandHanlderTest
{
    public class ConsultarPermisosHandlerTest
    {
        private static int Id = 0;

        [TestCase]
        public void consultaPermisos_retornaLitaEstructurada() {
            var mockRepo =new Mock<IPermisoRepository>();
            mockRepo.Setup(p => p.GetAll()).Returns(permiso());
            var MockMapper = new Mock<IMapper>();

            MockMapper.Setup(p => p.Map<DtoPermiso>(It.IsAny<Permiso>())).Returns(new DtoPermiso());
            var servicio = new Mock<IConsultaPermisoService>();
            servicio.Setup(p => p.Estructurar(It.IsAny<IEnumerable<DtoPermiso>>())).Returns(new List<DtoPermiso>());

            var instancia = new ConsultarPermisosHandler(MockMapper.Object, mockRepo.Object, servicio.Object);
            var lista = instancia.ejecutar(new ConsultarPermisos());

            Assert.IsInstanceOf<DtoPermisos>(lista);
        }


        public IQueryable<Permiso> permiso() {
            var lista = new List<Permiso>();
            var permisoModuloAutenticacion = new Permiso { Id = getId(), Codigo = "administracion", EsMenu = true, Nombre = "ADMINISTRACIÓN", Orden = 1, Url = "" };
            var permisoUsuario = new Permiso { PermisoPadre = permisoModuloAutenticacion.Id, Id = getId(), Codigo = "usuarios", EsMenu = true, Nombre = "Lista Usuarios", Orden = 1, Url = "/usuario", Icono = "icon-people" };
            var permisoUsuarioCrear = new Permiso { PermisoPadre = permisoModuloAutenticacion.Id, Id = getId(), Codigo = "usuario-crear", EsMenu = false, Nombre = "Crear usuario", Orden = 1, Url = "/usuario/crear" };
            var permisoRol = new Permiso { PermisoPadre = permisoModuloAutenticacion.Id, Id = getId(), Codigo = "roles", EsMenu = true, Nombre = "Lista roles", Orden = permisoUsuario.Orden + 1, Url = "/rol", Icono = "icon-key" };
            var permisoRolCrear = new Permiso { PermisoPadre = permisoModuloAutenticacion.Id, Id = getId(), Codigo = "rol-crear", EsMenu = false, Nombre = "Crear rol", Orden = 1, Url = "/rol/crear" };
            lista.Add(permisoModuloAutenticacion);
            lista.Add(permisoUsuario);
            lista.Add(permisoUsuarioCrear);
            lista.Add(permisoRol);
            lista.Add(permisoRolCrear);
            return lista.AsQueryable();
        }

        private static int getId()
        {
            Id = Id + 1;
            return Id;
        }
    }
}
