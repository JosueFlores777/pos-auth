using Aplicacion.CommandHandlers.Rol;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Test.ComandHanlderTest
{
    public class ConsultarrolHandlerTest
    {

        [TestCase]
        public void consultaPermisos_retornaLitaEstructurada()
        {

            var mockRepo = new Mock<IRolRepository>();

            mockRepo.Setup(p => p.GetById(It.IsAny<int>())).Returns(new Rol());
            var MockMapper = new Mock<IMapper>();
            MockMapper.Setup(p => p.Map<DtoRol>(It.IsAny<Rol>())).Returns(new DtoRol());

            var respuesta = new ConsultarRolHandler(mockRepo.Object, MockMapper.Object);

            Assert.IsInstanceOf<DtoRol>(respuesta);
        }
    }
}
