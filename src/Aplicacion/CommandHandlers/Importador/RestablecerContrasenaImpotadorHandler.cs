using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Helpers;
using Dominio.Especificaciones;
using Dominio.Helpers;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Importador
{
    public class RestablecerContrasenaImpotadorHandler : AbstractHandler<RestablecerContrasenaImpotador>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IUsuarioRepository usuarioRepository;

        private readonly ICorreoHelper correoHelper;

        public RestablecerContrasenaImpotadorHandler(IImportadorRepository importadorRepository, IUsuarioRepository usuarioRepository, ICorreoHelper correoHelper)
        {
            this.importadorRepository = importadorRepository;
            this.usuarioRepository = usuarioRepository;
            this.correoHelper = correoHelper;
        }


        public override IResponse Handle(RestablecerContrasenaImpotador message)
        {
            var contrasena = StringHelper.RandomString(7);
            var usuario = usuarioRepository.Filter(new BuscarUsuarioPorIdentificador(message.Usuario)).FirstOrDefault();
            if (usuario != null)
            {
                var importador = importadorRepository.Filter(new BuscarImportadorPorCorreoIdentificador(message.Correo, message.Usuario)).FirstOrDefault();

                if (importador != null)
                {
                    usuario.RestablecerContrasenaImportador(contrasena);
                    usuarioRepository.Update(usuario.Id, usuario);
                    correoHelper.EnviarCorreoUsuarioCreado(importador.Identificador, contrasena, importador.Correo);
                    return new OkResponse();
                }
            }
            return new OkResponse();
        }
    }
}
