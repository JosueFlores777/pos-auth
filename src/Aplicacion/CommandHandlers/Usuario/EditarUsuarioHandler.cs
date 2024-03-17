using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using Aplicacion.Services;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories;
using IdentityModel.Client;
using System.Linq;
using Dominio.Especificaciones;

namespace Aplicacion.CommandHandlers.Usuario
{
    public class EditarUsuarioHandler : AbstractHandler<EditarUsuario>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly IUsuarioRolRepository usuarioRolRepository;
        private readonly IUsuarioRegionalRepository usuarioRegionalRepository;
        private readonly IUsuarioAreaRepository usuarioAreaRepository;
        public EditarUsuarioHandler(IUsuarioAreaRepository usuarioAreaRepository, IUsuarioRepository usuarioRepository, IMapper mapper, IUsuarioRolRepository usuarioRolRepository, IUsuarioRegionalRepository usuarioRegionalRepository)
        {
            this.usuarioRegionalRepository = usuarioRegionalRepository;
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.usuarioRolRepository = usuarioRolRepository;
            this.usuarioAreaRepository = usuarioAreaRepository;
        }

        public override IResponse Handle(EditarUsuario message)
        {

            var usuario = mapper.Map<Dominio.Models.Usuario>(message.Usuario);
            var dbUser = usuarioRepository.GetByIdConRoles(message.Usuario.Id);
            foreach (var item in dbUser.Roles) usuarioRolRepository.Delete(item.Id);
            
            dbUser.AdministradorCambiaContrasena(message.Usuario.Nombre, message.Usuario.DepartamentoId,
                message.Usuario.Contrasena, message.Usuario.Roles.Select(c=>c.Id).ToList(),message.Usuario.Activo);
            LimpiarUsuarioRegional(message.Usuario.Id);
            LimpiarUsuarioArea(message.Usuario.Id);
            dbUser.UsuarioRegional = usuario.UsuarioRegional;
            dbUser.UsuarioArea = usuario.UsuarioArea;

            usuarioRepository.Update(dbUser.Id, dbUser);
            return mapper.Map<DtoUsuarioResponse>(dbUser);
        }
        private void LimpiarUsuarioRegional(int idUsuarioRegional)
        {
            var usuariosRegionales = usuarioRegionalRepository.Filter(new BuscarUsuarioRegionalPorUsuario(idUsuarioRegional));
            foreach (var regiones in usuariosRegionales) usuarioRegionalRepository.Delete(regiones);
        }
        private void LimpiarUsuarioArea(int idUsuarioArea)
        {
            var usuarioAreas = usuarioAreaRepository.Filter(new BuscarUsuarioAreaPorUsuario(idUsuarioArea));
            foreach (var areas in usuarioAreas) usuarioAreaRepository.Delete(areas);
        }
    }

}
