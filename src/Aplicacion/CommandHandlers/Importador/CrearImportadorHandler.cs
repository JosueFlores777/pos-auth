using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using AutoMapper;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Importador
{
    public class CrearImportadorHandler : AbstractHandler<CrearImportador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IMapper mapper;
        public CrearImportadorHandler(IImportadorRepository importadorRepository, IMapper mapper)
        {
            this.importadorRepository = importadorRepository;
            this.mapper = mapper;
        }

        public override IResponse Handle(CrearImportador message)
        {
            var importador = mapper.Map<Dominio.Models.Importardor>(message.Importador);
            importador.CorreoVerificado = false;
            var importadorCreado = importadorRepository.Create(importador);
            return mapper.Map<DtoImportador>(importadorCreado);
        }
    }
}
