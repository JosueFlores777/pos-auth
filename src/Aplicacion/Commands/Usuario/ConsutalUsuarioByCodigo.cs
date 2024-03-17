using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Usuario
{
    public class ConsutalUsuarioByCodigo : IMessage
    {
        public string CodigoTemporal { get; set; }
        public string Correo { get; set; }
    }
}
