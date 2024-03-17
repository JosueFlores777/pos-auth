using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using Dominio.Especificaciones;
using Dominio.Models.Regla;
using Dominio.Repositories;
using Dominio.Service;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators
{
    public class CambioContrasenaValidator : Validador<CambioContrasena>
    {
        private readonly ICambioPassword cambioPassword;
        private readonly ITokenService tokenService;


        public CambioContrasenaValidator(IAutenticationHelper autenticationHelper, ICambioPassword cambioPassword, ITokenService TokenService, IUsuarioRepository usuarioRepository) : base(autenticationHelper)
        {
            RuleFor(x => x.Id).NotEmpty().Must(c => TokenService.VerificarToken())
                .WithMessage("Token Invalido");
            RuleFor(x => x.Contrasena).Must(c =>!string.IsNullOrWhiteSpace(c)).WithMessage("La contrasena es requerida");

            RuleFor(x => x).Must(c=>VerificarPropietario(c.Id)).WithMessage("No puedes cambiar la contraseña por que la cuenta no es propietaria").
                        Must(x => VerificarContrasena(x.Id,x.Contrasena)).WithMessage("No puedes utilizar la misma contraseña");
            RuleFor(x => x).NotEmpty().Must(c => usuarioRepository.Filter(new BuscarUsuarioInternoPorIdentificador(c.IdentificadorAcceso)).Where(s=>s.Id != c.Id).Count() == 0  )
               .WithMessage("Ya existe un usuario con el mismo Correo");
            this.cambioPassword = cambioPassword;
            tokenService = TokenService;
        }
        private bool VerificarPropietario(int id) { 
                return id.Equals(tokenService.GetIdUsuario());
        }

        private bool VerificarContrasena(int id, string contrasena) {

                return cambioPassword.verificarPasswor(id, contrasena).Cumple;
        }
        public override IList<string> Permisos => new List<string> { };
    }
}
