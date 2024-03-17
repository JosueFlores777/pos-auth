using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
     class ConsutalUsuarioByCodigoValidator : Validador<ConsutalUsuarioByCodigo>
    {
        public ConsutalUsuarioByCodigoValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
            RuleFor(x => x.CodigoTemporal).NotEmpty();
        }
        public override IList<string> Permisos => new List<string>();
    }
}
