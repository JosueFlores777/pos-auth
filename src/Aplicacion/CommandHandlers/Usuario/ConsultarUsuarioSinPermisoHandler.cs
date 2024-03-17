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
    class ConsultarUsuarioSinPermisoHandler : AbstractHandler<ConsultarUsuarioSinPermiso>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public ConsultarUsuarioSinPermisoHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }
        public override IResponse Handle(ConsultarUsuarioSinPermiso message)
        {
            var usuario = usuarioRepository.GetByIdConRoles(message.Id);
            return mapper.Map<DtoUsuarioResponse>(usuario);
        }
    }
}
