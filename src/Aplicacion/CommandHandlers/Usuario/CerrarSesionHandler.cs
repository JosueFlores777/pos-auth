using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    public class CerrarSesionHandler : AbstractHandler<CerrarSesion>
    {
        private readonly ITokenService tokenService;

        public CerrarSesionHandler(ITokenService tokenService) {
            this.tokenService = tokenService;
        }
        public override IResponse Handle(CerrarSesion message)
        {
            this.tokenService.EliminarToken();
            return new OkResponse();
        }
    }
}
