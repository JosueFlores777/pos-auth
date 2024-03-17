using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class GestionarAccesoValidator : Validador<GestionarAcceso>
    {
        private readonly IImportadorRepository importadorRepository;

        public GestionarAccesoValidator(IAutenticationHelper autenticationHelper, IImportadorRepository importadorRepository) : base(autenticationHelper)
        {
            RuleFor(x => x.ImportadorId).NotEmpty().Must(c => ImportadorTieneAcceso(c))
                .WithMessage("No se le ha creado un usuario al importador");
            RuleFor(x => x.Accesos).NotEmpty().Must(list => list.Count > 0)
            .WithMessage("Debes incluir al menos un item");
            RuleFor(x => x).NotEmpty().Must(c => PuedeSolicitarAcceso(c)).WithMessage("No puedes aprobar accesos que no han sidoSolicitados");
            this.importadorRepository = importadorRepository;
        }
        private bool ImportadorTieneAcceso(int importadorId)
        {
            var importado = importadorRepository.GetById(importadorId);
            return importado.AccesoAprobado;
        }
        public bool PuedeSolicitarAcceso(GestionarAcceso gestionAcceso)
        {
            var importador = importadorRepository.GetByIdConDependencias(gestionAcceso.ImportadorId);
            if (importador == null) return true;
            return false;
        }

        public override IList<string> Permisos => new List<string> { "gestionar-accesos-importador" };
    }
}
