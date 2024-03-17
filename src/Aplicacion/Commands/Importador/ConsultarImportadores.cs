using Dominio.Repositories.Extenciones;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
   public class ConsultarImportadores: QueryStringParameters ,IMessage
    {
        public string Consulta { get; set; }
        public string identificador { get; set; }
    }
}
