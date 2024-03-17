using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Rol
{
    public class ConsultarRol : IMessage
    {
        public int id { get; set; }
    }
}
