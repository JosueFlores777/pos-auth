using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class CrearImportador : IMessage, IResponse
    {
        public DtoImportador Importador { get; set; }
    }
}
