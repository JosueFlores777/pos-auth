using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class ConsultarImportadoresValidator : Validador<ConsultarImportadores>
    {
        public ConsultarImportadoresValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
        }

        public override IList<string> Permisos => new List<string> { "listar-importadores", "importador-semilla-crear", "crear-establecimiento-salud-animal", "proveedor-fertilizante-crear" };
    }
}
