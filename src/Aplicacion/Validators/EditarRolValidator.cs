﻿using Aplicacion.Commands.Rol;
using Aplicacion.Services.Validaciones;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators
{
    public class EditarRolValidator : Validador<EditarRol>
    {
        public EditarRolValidator(IRolRepository rolRepository, IAutenticationHelper autenticationHelper):base(autenticationHelper)
        {

            RuleFor(x => x.Rol).NotEmpty().Must(c => rolRepository.Filter(new Func<Dominio.Models.Rol, bool>(p => p.Nombre == c.Nombre && p.Id!=c.Id)).Count() == 0)
               .WithMessage("Ya existe un rol con el mismo nombre"); ;
            RuleFor(x => x.Rol.Descripcion).NotEmpty();
            RuleFor(x => x.Rol.Permisos).NotEmpty();
        }
        public override IList<string> Permisos => new List<string> { "rol-editar" };

    }
}
