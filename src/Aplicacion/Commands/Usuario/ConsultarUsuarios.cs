using Dominio.Repositories.Extenciones;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Usuario
{
    public class ConsultarUsuarios : QueryStringParameters, IMessage
    {
        public string Nombre { get; set; }
        public string correo { get; set; }
        public int idDepartamento { get; set; }
    }
}
