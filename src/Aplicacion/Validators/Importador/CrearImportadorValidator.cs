using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class CrearImportadorValidator : Validador<CrearImportador>
    {
        public CrearImportadorValidator(IImportadorRepository importadorRepository, IAutenticationHelper autenticationHelper) : base(autenticationHelper)
        {
            RuleFor(x => x.Importador.Nombre).NotEmpty().Must(c => importadorRepository.Filter(new Func<Dominio.Models.Cliente, bool>(p => p.Nombre == c)).Count() == 0)
                .WithMessage("Ya existe un Importador con el mismo nombre");
            RuleFor(x => x.Importador.Identificador).NotEmpty().Must(c => importadorRepository.Filter(new Func<Dominio.Models.Cliente, bool>(p => p.Identificador == c)).Count() == 0)
                .WithMessage("Ya existe un Importador con el mismo Identificador");
            RuleFor(x => x.Importador.Identificador).NotEmpty();
            RuleFor(x => x.Importador.NacionalidadId).NotEmpty();
            RuleFor(x => x.Importador.DepartamentoId).NotEmpty();
            RuleFor(x => x.Importador.MunicipioId).NotEmpty();
        }
        public override IList<string> Permisos => new List<string> { };
    }
}
