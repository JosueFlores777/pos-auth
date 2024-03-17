using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    class ConsutalUsuarioByCodigoHandler : AbstractHandler<ConsutalUsuarioByCodigo>
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository usuarioRepository;

        public ConsutalUsuarioByCodigoHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            this.mapper = mapper;
            this.usuarioRepository = usuarioRepository;
        }
        public override IResponse Handle(ConsutalUsuarioByCodigo message)
        {
            var usuario = usuarioRepository.GetUsuarioConRolPermiso(new BuscarUsuarioPorIdentificadorYCodigo(message.Correo, message.CodigoTemporal));
            return mapper.Map<DtoUsuarioResponse>(usuario);
        }
    }
}
