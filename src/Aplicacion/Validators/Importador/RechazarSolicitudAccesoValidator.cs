using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Repositories;
using FluentValidation;
using System.Collections.Generic;

namespace Aplicacion.Validators.Importador
{
    public class RechazarSolicitudAccesoValidator : Validador<RechazarSolicitudAcceso>
    {
        private readonly IImportadorRepository importadorRepository;

        public RechazarSolicitudAccesoValidator(IAutenticationHelper autenticationHelper, IImportadorRepository importadorRepository) : base(autenticationHelper)
        {
            RuleFor(x => x.ImportadorId).NotEmpty().Must(c=>ImportadorSolicitudExiste(c)).WithMessage("No es posible gestinar esta solictud por que ya fue aprobada o no existe");
            RuleFor(x => x.Motivo).NotEmpty().WithMessage("Comentario Obligatorio Al Rechazar");
            this.importadorRepository = importadorRepository;
        }

        public bool ImportadorSolicitudExiste(int importadorId) {
            var importador = importadorRepository.GetById(importadorId);
            if (importador == null) return false;
            if (importador.AccesoAprobado) return false;
            return true;
        }
        public override IList<string> Permisos => new List<string> { "gestionar-importador" };
    }
}
