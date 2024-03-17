using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    public class EditarContrasenaHandler : AbstractHandler<EditarContrasena>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public EditarContrasenaHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        public override IResponse Handle(EditarContrasena message)
        {
            var dbUser = usuarioRepository.GetById(message.Id);
            dbUser.PropietarioCambiaContrasena(message.Contrasena);
            usuarioRepository.Update(dbUser.Id, dbUser);
            return new OkResponse();
        }
    }
}
