using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Dtos.Usuario
{
    class DtoUsuarioLogin: DtoUsuarioBase, IResponse
    {
        public string Token { get; set; }

    }
}
