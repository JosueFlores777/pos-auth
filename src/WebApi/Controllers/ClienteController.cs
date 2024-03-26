using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Commands.Importador;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using Aplicacion.Services.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public ICommandBus CommandBus { get; private set; }

        public ClienteController(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
        [HttpGet("lista", Name = "consultaImportadores")]
        public IResponse GetImportadores([FromQuery] ConsultarImportadores ownerParameter)
        {
            var respuesta = CommandBus.execute(ownerParameter);

            return respuesta;
        }

        [HttpGet("{id}", Name = "consultaImportador")]
        public IResponse GetImportador(int id)
        {
            var respuesta = CommandBus.execute(new ConsultarImportador { IdImportador=id});

            return respuesta;
        }
        [HttpGet("identificador/{id}", Name = "consultaImportadorPorIdentificador")]
        public IResponse GetImportadorPorIdentificador(string id)
        {
            var respuesta = CommandBus.execute(new ConsultarImportadorPorIdentificador { IdImportador = id });

            return respuesta;
        }
        [HttpGet("usuario/{id}", Name = "consultaImportadorPorIdUsuario")]
        public IResponse GetImportadorPorUsuario(int id)
        {
            var respuesta = CommandBus.execute(new ConsultarImportadorPorIdUsuario { IdUsuario = id });

            return respuesta;
        }

        [HttpPost("invitar", Name = "invitarImportador")]
        public void Post([FromBody] InvitarImportador value)
        {
            CommandBus.execute(value);
        }

        [HttpPost("rechazar", Name = "rechazarImportador")]
        public void Rechazar([FromBody] RechazarSolicitudAcceso value)
        {
            CommandBus.execute(value);
        }

        [HttpPost("solicitar-acceso", Name = "SolicitudAcceso")]
        public void SolicitudAcceso([FromBody] DtoImportador value)
        {
            CommandBus.execute(new SolicitarAcceso { Importador=value});
        }

        [HttpPut("verificar-correo" ,Name="verificarCorreo")]
        public void VerificarCorreo([FromBody] VerificarCorreo verificarCorreo)
        {
            CommandBus.execute(verificarCorreo);
        }

        [HttpPost("gestionar-accesos", Name = "gestionar-accesos")]
        public void GestionarAccesos([FromBody] GestionarAcceso value)
        {
            CommandBus.execute(value);
        }

        [HttpPost("actualizar-importador", Name = "editarImportador")]
        public IResponse Put([FromBody] DtoImportador value)
        {
            return CommandBus.execute(new EditarImportador { Importador = value });

        }
        [HttpPost]
        public void Post([FromBody] DtoImportador importador)
        {
            CommandBus.execute(new CrearImportador { Importador = importador });
        }

    }
}
