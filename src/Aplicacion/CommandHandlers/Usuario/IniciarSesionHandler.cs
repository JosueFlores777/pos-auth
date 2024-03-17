using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    public class IniciarSesionHandler : AbstractHandler<IniciarSesion>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        private readonly IUsuarioAreaRepository usuarioAreaRepository;

        public IniciarSesionHandler(IUsuarioRepository usuarioRepository, IMapper mapper, IUsuarioAreaRepository usuarioAreaRepository,
            ITokenService tokenService)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.usuarioAreaRepository = usuarioAreaRepository;
            this.tokenService = tokenService;
        }


        public override IResponse Handle(IniciarSesion message)
        {
            DtoUsuarioLogin respuesta;
            Dominio.Models.Usuario usuario;
            usuario = usuarioRepository.GetUsuarioConRolPermiso(new BuscarUsuarioPorIdentificadorYContrasena(message.Usuario, message.Contrasena));
  
            respuesta = mapper.Map<DtoUsuarioLogin>(usuario);
            respuesta.Token = tokenService.CrearOtraerToken(usuario);
            return respuesta;

        }
   
    }
}
