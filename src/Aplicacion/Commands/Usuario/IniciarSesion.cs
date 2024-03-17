using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Usuario
{
    public class IniciarSesion: IMessage
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

    }
}
