using Aplicacion.Commands;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class ConsultarPermisosValidator : Validador<ConsultarPermisos>
    {
        public ConsultarPermisosValidator(IAutenticationHelper autenticationHelper):base(autenticationHelper) { }
        public override IList<string> Permisos => new List<string> { "rol-crear" };
    }
}
