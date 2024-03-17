using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Usuario
{
    public class CodigoTemporal : IMessage
    {
        public string IdentificadorAcceso { get; set; }
    }
}
