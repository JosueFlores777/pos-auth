using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using Aplicacion.Helpers;
using AutoMapper;
using Dominio.Repositories;
using System.Linq;
using Dominio.Helpers;

namespace Aplicacion.CommandHandlers.Usuario
{
    public class RegistrarUsuarioHandler : AbstractHandler<RegistrarUsuario>
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICorreoHelper correoHelper;
        public RegistrarUsuarioHandler(IMapper mapper, ICorreoHelper correoHelper, IUsuarioRepository usuarioRepository)
        {
            this.mapper = mapper;
            this.usuarioRepository = usuarioRepository; 
            this.correoHelper = correoHelper;
        }
        public override IResponse Handle(RegistrarUsuario message)
        {
            var contrasena = StringHelper.RandomString(7);
            var usuario = mapper.Map<Dominio.Models.Usuario>(message.Usuario);
            usuario.Contrasena = contrasena;
            usuario.Inicializar(Dominio.Models.Usuario.usuarioInterno, message.Usuario.Roles.Select(c=>c.Id).ToList());
            usuarioRepository.Create(usuario);
            correoHelper.EnviarCorreoUsuarioCreado(message.Usuario.IdentificadorAcceso, contrasena, message.Usuario.IdentificadorAcceso);
            return new OkResponse();
        }
    }
}


