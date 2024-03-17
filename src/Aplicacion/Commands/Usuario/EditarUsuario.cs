using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Usuario
{
    public class EditarUsuario : IMessage
    {
        public DtoUsuario Usuario { get; set; }
    }
}
