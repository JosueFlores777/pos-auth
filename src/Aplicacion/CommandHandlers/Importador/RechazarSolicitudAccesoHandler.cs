using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Dominio.Helpers;
using Dominio.Repositories;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Importador
{
    public class RechazarSolicitudAccesoHandler : AbstractHandler<RechazarSolicitudAcceso>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly ITokenService tokenService;
        private readonly ICorreoHelper correoHelper;

        public RechazarSolicitudAccesoHandler(IImportadorRepository importadorRepository, ITokenService tokenService, ICorreoHelper correoHelper)
        {
            this.importadorRepository = importadorRepository;
            this.tokenService = tokenService;
            this.correoHelper = correoHelper;
        }

        public override IResponse Handle(RechazarSolicitudAcceso message)
        {
            var importador = importadorRepository.GetById(message.ImportadorId);
            importador.DenegarAcceso(tokenService.GetIdUsuario(), message.Motivo);
            correoHelper.EnviarCorreoDenegacionAcceso(importador.Correo, message.Motivo);
            importadorRepository.Update(importador.Id, importador);
            return new OkResponse();
        }
    }
}
