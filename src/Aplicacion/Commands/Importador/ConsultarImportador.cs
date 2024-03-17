using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class ConsultarImportador:IMessage
    {
        public int IdImportador { get; set; }
    }
}
