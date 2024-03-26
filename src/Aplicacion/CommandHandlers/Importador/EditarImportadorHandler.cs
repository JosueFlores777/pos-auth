using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Helpers;
using AutoMapper;
using Dominio.Models;
using Dominio.Especificaciones;
using Dominio.Helpers;
using Dominio.Repositories;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Aplicacion.CommandHandlers.Importador
{
    public class EditarImportadorHandler : AbstractHandler<EditarImportador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly ITokenService tokenSrvice;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICorreoHelper correoHelper;
        private readonly IMapper mapper;
        public EditarImportadorHandler(IImportadorRepository importadorRepository, ITokenService tokenSrvice,
             IUnitOfWork unitOfWork, ICorreoHelper correoHelper, IMapper mapper)
        {
            this.mapper = mapper;
            this.importadorRepository = importadorRepository;
            this.tokenSrvice = tokenSrvice;
            this.unitOfWork = unitOfWork;
            this.correoHelper = correoHelper;
        }

        public override IResponse Handle(EditarImportador message)
        {
            var importardor = importadorRepository.GetById(message.Importador.Id.Value);
            var impo = mapper.Map<Dominio.Models.Cliente>(message.Importador);
            var CorreoViejo = importardor.Correo;
            var cambioCorreo = importardor.Correo != message.Importador.Correo;
            importardor.ActulizarImportador(impo);
            if (cambioCorreo){
                importadorRepository.Update(importardor.Id, importardor);
                unitOfWork.Save();
                correoHelper.EnviarCorreoParaActulizacion(CorreoViejo, impo.TokenVerificacion,(DateTime)importardor.FechaModificacion,impo.Correo);
            }else{
                importadorRepository.Update(importardor.Id, importardor);
            }
            return new OkResponse();
        }
    }
}
