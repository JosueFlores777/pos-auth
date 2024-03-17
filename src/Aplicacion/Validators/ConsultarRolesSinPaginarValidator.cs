using Aplicacion.Commands.Rol;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class ConsultarRolesSinPaginarValidator : Validador<ConsultarRolesSinPaginar>
    {
        public ConsultarRolesSinPaginarValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper) { 
        }
        public override IList<string> Permisos => new List<string> { "usuario-crear", "crear-anuncio" };
    }
}
