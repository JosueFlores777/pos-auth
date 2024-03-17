using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    class ConsultarUsuarioValidator : Validador<ConsultarUsuario>
    {
        public ConsultarUsuarioValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
            RuleFor(x => x.Id).NotEmpty();
        }
        public override IList<string> Permisos => new List<string> { "usuario-editar", "usuario-ver", "usuario-editar-staff" };
    }
}