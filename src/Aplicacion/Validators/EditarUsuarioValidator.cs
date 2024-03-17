using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class EditarUsuarioValidator : Validador<EditarUsuario>
    {
        public EditarUsuarioValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper) { }
        public override IList<string> Permisos => new List<string> { "usuario-editar" };
    }
}
