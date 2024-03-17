using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class VerificarCorreo:IMessage
    {
        public string Token { get; set; }
    }
}
