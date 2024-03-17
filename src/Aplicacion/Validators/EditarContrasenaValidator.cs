using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using Dominio.Models.Regla;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators
{
    public class EditarContrasenaValidator : Validador<EditarContrasena>
    {
        private readonly ICambioPassword cambioPassword;


        public EditarContrasenaValidator(IAutenticationHelper autenticationHelper, ICambioPassword cambioPassword, IUsuarioRepository usuarioRepository) : base(autenticationHelper)
        {
            RuleFor(x => x.Contrasena).Must(c => !string.IsNullOrWhiteSpace(c)).WithMessage("La contrasena es requerida");

            RuleFor(x => x).Must(x => VerificarContrasena(x.Id, x.Contrasena)).WithMessage("No puedes utilizar la misma contraseña");
            this.cambioPassword = cambioPassword;
        }
        private bool VerificarContrasena(int id, string contrasena)
        {

            return cambioPassword.verificarPasswor(id, contrasena).Cumple;
        }
        public override IList<string> Permisos => new List<string> { };
    }
}
