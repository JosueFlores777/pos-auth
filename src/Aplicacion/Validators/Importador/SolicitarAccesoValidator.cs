using Aplicacion.Commands.Importador;
using Aplicacion.Services.Validaciones;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Especificaciones;

namespace Aplicacion.Validators.Importador
{
    public class SolicitarAccesoValidator : Validador<SolicitarAcceso>
    {
        private readonly IArchivoRepository archivoRepository;
        private readonly IImportadorRepository importadorRepository;
        private readonly IUsuarioRepository usuarioRepository;



        public SolicitarAccesoValidator(IAutenticationHelper autenticationHelper, IArchivoRepository archivoRepository,
            IImportadorRepository importadorRepository, IUsuarioRepository usuarioRepository) : base(autenticationHelper)
        {

            RuleFor(x => x).NotEmpty()
                .Must(c => UsuarioNoExiste(c.Importador.Identificador, c.Importador.Correo, c))
                .WithMessage("Su combinacion de Rtn y Correo no existe");
            RuleFor(x => x).NotEmpty()
                .Must(c => UsuarioYaRegistrado(c.Importador.Identificador, c.Importador.Correo, c))
                .WithMessage("El Importador ya esta ingresado en el sistema");
            RuleFor(x => x).NotEmpty()
              .Must(c => Tieneusuario(c.Importador.Identificador, c)).WithMessage(("Ya existe un usuario con los roles que ha solicitado"));
            RuleFor(x => x.Importador.Correo).NotEmpty().EmailAddress();



            this.archivoRepository = archivoRepository;
            this.importadorRepository = importadorRepository;
            this.usuarioRepository = usuarioRepository;
        }

        private bool Tieneusuario(string identificador, SolicitarAcceso importadorAcceso)
        {
            var impotador = importadorRepository.Filter(new Func<Importardor, bool>(c => c.Identificador == identificador)).FirstOrDefault();
            var usuario = usuarioRepository.Filter(new BuscarUsuarioPorIdentificador(identificador));
            if (usuario.Count() == 0) { return true; }
            else
            {
                var user = usuarioRepository.GetUsuarioConRolPermiso(new BuscarUsuarioPorIdentificador(identificador));

                if (impotador != null )
                {
                    return true;

                }
                else { return false; }
            }
        }
        private bool MismoCorreo(string identificador, string Correo, SolicitarAcceso importadorAcceso)
        {
            
            var usuario = usuarioRepository.Filter(new BuscarUsuarioPorIdentificador(identificador));
            if (usuario.Count() == 0) { return true; }
            else
            {
                var impotador = importadorRepository.Filter(new Func<Importardor, bool>(c => c.Identificador == identificador)).FirstOrDefault();
                if (impotador != null && Correo == impotador.Correo)
                { return true; }
                else
                { return false; }
            }
            
            


        }

        private bool UsuarioYaRegistrado(string identificador, string Correo, SolicitarAcceso importadorAcceso)
        {
            
            var impotador = importadorRepository.Filter(new Func<Importardor, bool>(c => c.Identificador == identificador)).FirstOrDefault();
            if (impotador == null)
            {
                return true;
            }
            else if (!impotador.AccesoAprobado)
            {

                return true;
            }
            else {
                return false;
            }

            

        }
        private bool UsuarioNoExiste(string identificador, string Correo, SolicitarAcceso importadorAcceso)
        {

            var impotador = importadorRepository.Filter(new Func<Importardor, bool>(c => c.Identificador == identificador && c.Correo == Correo)).FirstOrDefault();

            if (importadorAcceso.Importador.UserExist)
            {

                if (impotador == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return true;
            }


        }

        public override IList<string> Permisos => new List<string>();
    }
}
