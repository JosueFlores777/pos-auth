using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Helpers;
using Dominio.Helpers;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Service;
using AutoMapper;
using Aplicacion.Dtos.Usuario;
using Dominio.Especificaciones;
using System.Collections.Generic;
using System;


namespace Aplicacion.CommandHandlers.Importador
{
    public class InvitarImportadorHandler : AbstractHandler<InvitarImportador>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IImportadorRepository importadorRepository;
        private readonly ICorreoHelper correoHelper;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        private readonly IUsuarioRolRepository usuarioRolRepository;
        public InvitarImportadorHandler(IUsuarioRepository usuarioRepository, 
            IImportadorRepository importadorRepository, ICorreoHelper correoHelper, ITokenService tokenService, IMapper mapper, IUsuarioRolRepository usuarioRolRepository) {
            this.usuarioRepository = usuarioRepository;
            this.importadorRepository = importadorRepository;
            this.correoHelper = correoHelper;
            this.tokenService = tokenService;
            this.mapper = mapper;
            this.usuarioRolRepository = usuarioRolRepository;
        }
        public override IResponse Handle(InvitarImportador message)
        {

            message.Accesos = Dominio.Models.Usuario.PermisosUsuarioExterno;
            var importador = importadorRepository.GetByIdConDependencias(message.ImportadorId);
            var contrasena = StringHelper.RandomString(7);

            var usuario = new Dominio.Models.Usuario { Contrasena = contrasena, IdentificadorAcceso = importador.Identificador, Nombre = importador.Nombre, DepartamentoId = 14 };

            usuario.Inicializar(Dominio.Models.Usuario.tipoUsuarioImportador, message.Accesos);
            usuarioRepository.Create(usuario);
            correoHelper.EnviarCorreoUsuarioCreado(importador.Identificador, contrasena, importador.Correo);
            importador.FinalizarEnvitacion(tokenService.GetIdUsuario(), message.Accesos);

            importadorRepository.Update(importador.Id, importador);
               
            
            

            return new OkResponse();

        }
    }
}
