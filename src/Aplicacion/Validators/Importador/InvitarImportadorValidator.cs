using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Especificaciones;
using Dominio.Models.Regla;
using Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Aplicacion.Validators.Importador
{
    public class InvitarImportadorValidator : Validador<InvitarImportador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public InvitarImportadorValidator(IAutenticationHelper autenticationHelper, IImportadorRepository importadorRepository, IImportadoresCorreoEnviado importadoresCorreoEnviado, IUsuarioRepository usuarioRepository) : base(autenticationHelper)
        {
            //RuleFor(x => x).NotEmpty().Must(c => !importadoresCorreoEnviado.VerificarCorreoEnviado(c.ImportadorId))
            //    .WithMessage("El usuario ya fue invitado").Must(c=>NoExisteUsuario(c.ImportadorId, c)).WithMessage("No puedes volver asignarle roles que ya tiene el usuario");
                  
            this.importadorRepository = importadorRepository;
            this.usuarioRepository = usuarioRepository;
        }

        private bool NoExisteUsuario(int importadorId, InvitarImportador iv) {
            var importador = importadorRepository.GetById(importadorId);
            var usuario = usuarioRepository.Filter(new BuscarUsuarioPorIdentificador(importador.Identificador));
            var user = usuarioRepository.GetUsuarioConRolPermiso(new BuscarUsuarioPorIdentificador(importador.Identificador));
            if (usuario.Count() != 0)
            {
                foreach (var roles in iv.Accesos)
                {
                    foreach (var UsuarioRoles in user.Roles)
                    {

                        if ( UsuarioRoles.RolId == 2 && roles == 2)
                        {
                            return false;
                        }

                        else if (UsuarioRoles.RolId == 1 && roles == 1)
                        {
                            

                            return false;
                        }
                        else if (UsuarioRoles.RolId == 23 && roles == 23)
                        {
                            
                            return false;
                        }
                        else if (UsuarioRoles.RolId == 37 && roles == 37){return false;}


                    }
                }
                return true;
            }
            return usuario.Count() == 0;
        }
        
        public override IList<string> Permisos => new List<string> { "gestionar-importador" };
    }
}
