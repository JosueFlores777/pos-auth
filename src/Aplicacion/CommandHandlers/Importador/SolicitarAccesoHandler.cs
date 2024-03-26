using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Models;
using Dominio.Helpers;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aplicacion.CommandHandlers.Importador
{
    public class SolicitarAccesoHandler : AbstractHandler<SolicitarAcceso>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IMapper mapper;
        private readonly ICorreoHelper correoHelper;

        public SolicitarAccesoHandler(IImportadorRepository importadorRepository, IMapper mapper, ICorreoHelper correoHelper)
        {
            this.importadorRepository = importadorRepository;
            this.mapper = mapper;
            this.correoHelper = correoHelper;
        }
        public override IResponse Handle(SolicitarAcceso message)
        {
            
            var importador = mapper.Map<Dominio.Models.Cliente>(message.Importador);
            importador.SolicitarAcceso();
            var impotadorBusquedad = importadorRepository.Filter(new Func<Cliente, bool>(c => c.Identificador == message.Importador.Identificador)).FirstOrDefault();
            if (impotadorBusquedad == null)
            {
                importadorRepository.Create(importador);
            }
            else {
                importadorRepository.Update(impotadorBusquedad.Id, importador);
            }
            
            correoHelper.EnviarCorreoParaVerificacion(importador.Correo, importador.TokenVerificacion);

            return new OkResponse();
        }
    }
}
