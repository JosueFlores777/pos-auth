using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class ConsultarUsuariosValidator : Validador<ConsultarUsuarios>
    {
        public ConsultarUsuariosValidator(IAutenticationHelper autenticationHelper) : base(autenticationHelper) { }
        public override IList<string> Permisos => new List<string> { "usuario-listar", "usuarios", "firma-crear" };
    }
}
