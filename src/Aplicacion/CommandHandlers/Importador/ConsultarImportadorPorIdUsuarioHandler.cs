using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using AutoMapper;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Especificaciones;

namespace Aplicacion.CommandHandlers.Importador
{
    public class ConsultarImportadorPorIdUsuarioHandler : AbstractHandler<ConsultarImportadorPorIdUsuario>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IImportadorRepository importadorRepository;
        private readonly IMapper mapper;


        public ConsultarImportadorPorIdUsuarioHandler(IImportadorRepository importadorRepository, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.importadorRepository = importadorRepository;
            this.mapper = mapper;
        }

        public override IResponse Handle(ConsultarImportadorPorIdUsuario message)
        {
            var usuario = usuarioRepository.GetById(message.IdUsuario);
            var importador = importadorRepository.Filter(new BuscarImportadorPorIdentificador(usuario.IdentificadorAcceso)).FirstOrDefault();
            if (importador != null) return mapper.Map<DtoImportador>(importador);
            return new DtoImportador();
        }
    }
}
