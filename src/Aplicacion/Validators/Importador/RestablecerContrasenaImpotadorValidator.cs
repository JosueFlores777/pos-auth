using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Especificaciones;
using Dominio.Repositories;
using Dominio.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class RestablecerContrasenaImpotadorValidator : Validador<RestablecerContrasenaImpotador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IUsuarioRepository usuarioRepository;
        

        public RestablecerContrasenaImpotadorValidator(IAutenticationHelper autenticationHelper,
            IImportadorRepository importadorRepository, IUsuarioRepository usuarioRepository) : base(autenticationHelper)
        {
            RuleFor(x => x.Correo).NotEmpty().EmailAddress();
            RuleFor(x => x.Usuario).NotEmpty().Must(c=> RegexUtilities.IsValidEmail(c)==false).WithMessage("El usuario no puede ser un correo, para usuarios internos contacta al departamento de IT");
            RuleFor(x => x).Must(c => Buscarusuario(c)).WithMessage("No se ha encontrado un importador con el usuario y correo especificado");
            this.importadorRepository = importadorRepository;
            this.usuarioRepository = usuarioRepository;

        }
        private bool Buscarusuario(RestablecerContrasenaImpotador rc)
        {
            var encuentraUsuario = false;
            var usuario = usuarioRepository.Filter(new BuscarUsuarioPorIdentificador(rc.Usuario)).FirstOrDefault();
            if (usuario != null)
            {
                var importador = importadorRepository.Filter(new BuscarImportadorPorCorreoIdentificador(rc.Correo, rc.Usuario));
                if (importador.Count() > 0)encuentraUsuario = true;
            }
            return encuentraUsuario;

        }

        public override IList<string> Permisos => new List<string>();
    }
}
