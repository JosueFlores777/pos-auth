using Aplicacion.Dtos;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Rol
{
    public class CrearRol : IMessage, IResponse
    {
        public DtoRol Rol { get; set; }
    }
}
