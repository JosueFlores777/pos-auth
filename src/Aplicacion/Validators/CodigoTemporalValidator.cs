using Aplicacion.Commands.Usuario;
using Aplicacion.Services.Validaciones;
using Dominio.Especificaciones;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators
{
     class CodigoTemporalValidator : Validador<CodigoTemporal>
    {
        private readonly IImportadorRepository importRepo;
        private readonly IUsuarioRepository user;
        public CodigoTemporalValidator(IAutenticationHelper autenticationHelper, IImportadorRepository importRepo, IUsuarioRepository user) : base(autenticationHelper)
        {
            RuleFor(x => x.IdentificadorAcceso).NotEmpty().WithMessage("Ingrese un Correo/Identificacion");
            RuleFor(x => x).NotEmpty()
               .Must(c => ValidarUsuario(c.IdentificadorAcceso))
               .WithMessage("Identificador / Correo no registrado ");
            this.importRepo = importRepo;
            this.user = user;
        }
        private bool ValidarUsuario(string identificador)
        {
            var usuario = user.Filter(new BuscarUsuarioPorIdentificador(identificador));
            return usuario.Count() > 0;

        }
        public override IList<string> Permisos => new List<string>();
    }
}
