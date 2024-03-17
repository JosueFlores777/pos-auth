using Aplicacion.Commands.Rol;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Helpers;
using Dominio.Repositories;
using Dominio.Service;

namespace Aplicacion.CommandHandlers.Rol
{
    public class CrearRolHandler : AbstractHandler<CrearRol>
    {
        private readonly IRolRepository rolRepository;
        private readonly IMapper mapper;
        private readonly ICorreoHelper correoHelper;
        private readonly ITokenService tokenService;
        private readonly IUsuarioRepository usuarioRepository;
        public CrearRolHandler(IRolRepository rolRepository, IMapper mapper, ICorreoHelper correoHelper, ITokenService tokenService, IUsuarioRepository usuarioRepository)
        {
            this.rolRepository = rolRepository;
            this.mapper = mapper;
            this.correoHelper = correoHelper;
            this.tokenService = tokenService;
            this.usuarioRepository = usuarioRepository;
        }

        public override IResponse Handle(CrearRol message)
        {
            var idUsuario = tokenService.GetIdUsuario();
            var usuario = usuarioRepository.GetById(idUsuario);

            var rol = mapper.Map<Dominio.Models.Rol>(message.Rol);
            rol.setFechaCreacion();
            rol.CrearRolPermiso(message.Rol.Permisos);
            rol.Asignable = true;
            var rolCreado = rolRepository.Create(rol);
            correoHelper.EnviarCorreoRolCreado(usuario.Nombre,message.Rol.Nombre);
            return mapper.Map<DtoRol>(rolCreado);
        }
    }
}
