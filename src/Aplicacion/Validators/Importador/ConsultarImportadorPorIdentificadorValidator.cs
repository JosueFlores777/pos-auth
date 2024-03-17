using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class ConsultarImportadorValidator : Validador<ConsultarImportador>
    {
        public ConsultarImportadorValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
        }

        public override IList<string> Permisos => new List<string> { };
    }
}
