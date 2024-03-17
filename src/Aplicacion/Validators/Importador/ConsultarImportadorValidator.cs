using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class ConsultarImportadorPorIdentificadorValidator : Validador<ConsultarImportadorPorIdentificador>
    {
        public ConsultarImportadorPorIdentificadorValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
        }

        public override IList<string> Permisos => new List<string> { };
    }
}
