using Aplicacion.Dtos.Importador;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class SolicitarAcceso:IMessage
    {
       public DtoImportador Importador { get; set; }
    }
}
