using Aplicacion.Commands.Rol;
using Aplicacion.Services.Validaciones;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class ConsultarRolValidator : Validador<ConsultarRol>
    {
        public ConsultarRolValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
            RuleFor(x => x.id).NotEmpty();
        }
        public override IList<string> Permisos => new List<string> { "rol-editar", "rol-verss" };
    }
}
