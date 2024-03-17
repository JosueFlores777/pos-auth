using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    class CambioContrasenaHandler : AbstractHandler<CambioContrasena>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public CambioContrasenaHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        public override IResponse Handle(CambioContrasena message)
        {
            var dbUser = usuarioRepository.GetById(message.Id);
            dbUser.IdentificadorAcceso = message.IdentificadorAcceso;
            dbUser.PropietarioCambiaContrasena(message.Contrasena);
            usuarioRepository.Update(dbUser.Id, dbUser);
            return new OkResponse();
        }
    }
}
