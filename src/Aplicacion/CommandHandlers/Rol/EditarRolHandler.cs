using Aplicacion.Commands.Rol;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Helpers;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Rol
{
    public class EditarRolHandler : AbstractHandler<EditarRol>
    {
        private readonly IRolRepository rolRepository;
        private readonly IMapper mapper;
        private readonly IRolPermisoRepository rolPermisoRepository;
        private readonly ICorreoHelper correoHelper;
        private readonly ITokenService tokenService;
        private readonly IUsuarioRepository usuarioRepository;
        public EditarRolHandler(IRolRepository rolRepository, IUsuarioRepository usuarioRepository, ITokenService tokenService, ICorreoHelper correoHelper , IMapper mapper, IRolPermisoRepository rolPermisoRepository)
        {
            this.rolRepository = rolRepository;
            this.mapper = mapper;
            this.rolPermisoRepository = rolPermisoRepository;
            this.correoHelper = correoHelper;
            this.tokenService = tokenService;
            this.usuarioRepository = usuarioRepository;
        }

        public override IResponse Handle(EditarRol message)
        {
            var idUsuario = tokenService.GetIdUsuario();
            var usuario = usuarioRepository.GetById(idUsuario);
            var dbrol = rolRepository.GetByIdConPermisos(message.Id);
            foreach (var item in dbrol.Permisos) rolPermisoRepository.Delete(item.Id);
            dbrol.actualizar(message.Rol.Nombre, message.Rol.Descripcion, message.Rol.Permisos);
            var rolCreado = rolRepository.Update(message.Id, dbrol);
            correoHelper.EnviarCorreoRolCreado(usuario.Nombre, message.Rol.Nombre);
            return mapper.Map<DtoRol>(rolCreado);
        }
    }
}
