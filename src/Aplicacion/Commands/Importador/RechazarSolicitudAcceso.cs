using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands.Importador
{
    public class RechazarSolicitudAcceso:IMessage
    {
        public int ImportadorId { get; set; }
        public string Motivo { get; set; }
    }
}
