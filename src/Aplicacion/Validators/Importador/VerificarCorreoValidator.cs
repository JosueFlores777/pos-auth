using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Especificaciones;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class VerificarCorreoValidator : Validador<VerificarCorreo>
    {
        private readonly IImportadorRepository importadorRepository;

        public VerificarCorreoValidator(IAutenticationHelper autenticationHelper, IImportadorRepository importadorRepository) : base(autenticationHelper)
        {
            RuleFor(x => x.Token).NotEmpty().Must(x=>ExisteSolicitud(x)).WithMessage("No encontramos registro de la solicitud.");
            this.importadorRepository = importadorRepository;
        }

        private bool ExisteSolicitud(string token) {
            var solicitud = importadorRepository.Filter(new BuscarImportadorPorTokenDeVerificacion(token));
            return solicitud.Count() == 1;
        }

        public override IList<string> Permisos => new List<string>();
    }
}
