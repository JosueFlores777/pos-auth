using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Dominio.Especificaciones;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Importador
{
    public class VerificarCorreoHandler : AbstractHandler<VerificarCorreo>
    {
        public VerificarCorreoHandler(IImportadorRepository importadorRepository)
        {
            ImportadorRepository = importadorRepository;
        }

        public IImportadorRepository ImportadorRepository { get; }

        public override IResponse Handle(VerificarCorreo message)
        {
            var importador = ImportadorRepository.Filter(new BuscarImportadorPorTokenDeVerificacion(message.Token)).FirstOrDefault();
            if (importador.CorreoVerificado) {
                return new OkResponse();
            }
            importador.VerificarCorreo();
            ImportadorRepository.Update(importador.Id, importador);
            return new OkResponse();
        }
    }
}
