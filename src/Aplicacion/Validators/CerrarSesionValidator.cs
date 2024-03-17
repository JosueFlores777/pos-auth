using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
   public class CerrarSesionValidator : Validador<CerrarSesion>
    {
        public CerrarSesionValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
        }
        public override IList<string> Permisos => new List<string>();
    }
}
