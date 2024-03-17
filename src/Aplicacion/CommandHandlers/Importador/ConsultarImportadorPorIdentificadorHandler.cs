using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using AutoMapper;
using Dominio.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Importador
{
    public class ConsultarImportadorPorIdentificadorHandler : AbstractHandler<ConsultarImportadorPorIdentificador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IMapper mapper;

        public ConsultarImportadorPorIdentificadorHandler(IImportadorRepository importadorRepository, IMapper mapper)
        {
            this.importadorRepository = importadorRepository;
            this.mapper = mapper;
        }

        public override IResponse Handle(ConsultarImportadorPorIdentificador message)
        {
            var importador = importadorRepository.Set().AsNoTracking().
                Include(c => c.Departamento).Include(c => c.Municipio).Include(c => c.Nacionalidad)
                .FirstOrDefault(c => c.Identificador == message.IdImportador);
            if (importador !=null) return mapper.Map<DtoImportador>(importador);
            return new DtoImportador();
        }
    }
}
