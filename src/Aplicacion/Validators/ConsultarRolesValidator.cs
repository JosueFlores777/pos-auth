using Aplicacion.Commands.Rol;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class ConsultarRolesValidator : Validador<ConsultarRoles>
    {
        public ConsultarRolesValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper) { }
        public override IList<string> Permisos => new List<string> { "rol-listar", "roles" };
    }
}
