using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class GestionarAcceso : IMessage
    {
        public int ImportadorId { get; set; }
        public List<int> Accesos { get; set; }
    }
}
