using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class ConsultarImportadorPorIdentificador:IMessage
    {
        public string IdImportador { get; set; }
    }
}
