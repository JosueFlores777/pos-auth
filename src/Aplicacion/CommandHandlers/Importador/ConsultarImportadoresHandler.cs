using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using Dominio.Repositories.Extensiones;

namespace Aplicacion.CommandHandlers.Importador
{
    public class ConsultarImportadoresHandler : AbstractHandler<ConsultarImportadores>
    {
        private readonly IImportadorRepository importadorRepository;
        private readonly IMapper mapper;

        public ConsultarImportadoresHandler(IImportadorRepository importadorRepository, IMapper mapper) {
            this.importadorRepository = importadorRepository;
            this.mapper = mapper;
        }
        public override IResponse Handle(ConsultarImportadores message)
        {
            IPagina<Dominio.Models.Cliente> respuesta;
            if (!string.IsNullOrWhiteSpace(message.identificador))
            {
                respuesta = importadorRepository.ConsultarPaginado(message, new BuscarImportadorPorIdentificador(message.identificador));
            }
            else
            {
                var consulta = !string.IsNullOrWhiteSpace(message.Consulta) ? message.Consulta : "FechaAprobacionAcceso = null AND CorreoVerificado=true"; //"FechaAprobacionAcceso = null AND FechaDenegacionAcceso = null AND CorreoVerificado=true";
                respuesta = importadorRepository.Filter(message, consulta);
            }
           
           return mapper.Map<DtoImportadoresPaginados>(respuesta); 
        }
    }
}
