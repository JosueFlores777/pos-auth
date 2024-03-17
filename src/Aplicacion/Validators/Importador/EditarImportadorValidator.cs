using Aplicacion.Commands.Importador;
using Aplicacion.Dtos.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Especificaciones;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class EditarImportadorValidator : Validador<EditarImportador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly ITokenService tokenService;
        public EditarImportadorValidator(IAutenticationHelper autenticationHelper,
            IImportadorRepository importadorRepository,
            ITokenService tokenService) : base(autenticationHelper)
        {

            RuleFor(x => x.Importador).NotEmpty().Must(c => PuedeeditarCorreo(c))
                 .WithMessage("Ya existe un usuario registrado con el correo");
            RuleFor(x => x.Importador.Telefono).NotEmpty().WithMessage("Ingresa Un Numero Telefonico");
            RuleFor(x => x.Importador.Celular).NotEmpty().WithMessage("Ingresa Un Numero Celular");
            RuleFor(x => x.Importador.Correo).NotEmpty().WithMessage("Ingresa Un Numero Correo");
            RuleFor(x => x.Importador.Direccion).NotEmpty().WithMessage("Ingresa Una Dirrecion ");
            //RuleFor(x => x.Importador.EncargadoImportaciones).NotEmpty().WithMessage("Ingresa el encargado");
            this.importadorRepository = importadorRepository;
            this.tokenService = tokenService;
        }
        private bool PuedeeditarCorreo(DtoImportador importador)
        {
            var imp = importadorRepository.GetById(importador.Id.Value);

            var todosConMismoCorreo = importadorRepository.Filter(new Func<Importardor, bool>(p => p.Correo == importador.Correo));
            if (todosConMismoCorreo.Count() == 0) return true;
            if (todosConMismoCorreo.Count() > 1) return false;
            if (todosConMismoCorreo.Count() == 1 && todosConMismoCorreo.First().Correo == imp.Correo) return true;
            return true;
        }
        public override IList<string> Permisos => new List<string> { "perfil-importador","importador-editar" };
    }

}
