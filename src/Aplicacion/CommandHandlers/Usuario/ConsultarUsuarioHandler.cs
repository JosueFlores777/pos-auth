using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using AutoMapper;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    class ConsultarUsuarioHandler : AbstractHandler<ConsultarUsuario>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public ConsultarUsuarioHandler(IUsuarioRepository usuarioRepository, IMapper mapper) {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }
        public override IResponse Handle(ConsultarUsuario message)
        {
            var usuario = usuarioRepository.GetByIdConRoles(message.Id);
            return mapper.Map<DtoUsuarioResponse>(usuario);
        }
    }
}
