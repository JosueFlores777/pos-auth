using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Commands.Importador;
using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using Aplicacion.Services.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ICommandBus commandBus;

        public string ExceptionMessage { get; private set; }

        public UsuarioController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        // GET: api/usuario
        [HttpGet]
        public IResponse GetUsuarios([FromQuery] ConsultarUsuarios ownerParameter)
        {
            var respuesta = commandBus.execute(ownerParameter);

            return respuesta;
        }

        // POST: api/Usuarios
        [HttpPost]
        public IResponse Post([FromBody] DtoUsuario usuario)
        {

            return commandBus.execute(new RegistrarUsuario { Usuario = usuario });
        }

        [HttpGet("{id}", Name = "ConsultarUsuarioPorId")]
        public IResponse Get(int id)
        {
            var respuesta = commandBus.execute(new ConsultarUsuario { Id = id });
            return respuesta;
        }

        [HttpPost]
        [Route("login")]
        public IResponse iniciarSesion([FromBody] IniciarSesion crenciales)
        {
            var respuesta = commandBus.execute(crenciales);
            return respuesta;
        }

        [HttpPost]
        [Route("cerrar-session")]
        public IResponse CerrarSesion([FromBody] CerrarSesion cerrarSesion)
        {
            var respuesta = commandBus.execute(cerrarSesion);
            return respuesta;
        }

        [HttpPost]
        [Route("cambiar-contrasena")]
        public IResponse CambiarContrasena([FromBody] CambioContrasena crenciales)
        {
            var respuesta = commandBus.execute(crenciales);
            return respuesta;
        }

        [HttpPost]
        [Route("restablecer-contrasena-importador")]
        public IResponse RestablecerContrasena([FromBody] RestablecerContrasenaImpotador datosRestablecer)
        {
            var respuesta = commandBus.execute(datosRestablecer);
            return respuesta;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DtoUsuario value)
        {
            commandBus.execute(new EditarUsuario { Usuario = value });
        }

        [HttpPost]
        [Route("codigo-temporal")]
        public IResponse CodigoTemportal([FromBody] CodigoTemporal codigoTemporal)
        {
            var respuesta = commandBus.execute(codigoTemporal);
            return respuesta;
        }

        [HttpPost]
        [Route("codigo")]
        public IResponse Codigo([FromBody] ConsutalUsuarioByCodigo codigoTemporal)
        {
            var respuesta = commandBus.execute(codigoTemporal);
            return respuesta;
        }

        [HttpPost]
        [Route("editar-contrasena")]
        public IResponse EditarContraseña([FromBody] EditarContrasena editarContrasena)
        {
            var respuesta = commandBus.execute(editarContrasena);
            return respuesta;
        }


        [HttpGet("GetSinPermiso/{id}", Name = "ConsultarUsuarioSinPerisoPorId")]
        public IResponse GetSinPermiso(int id)
        {
            var respuesta = commandBus.execute(new ConsultarUsuarioSinPermiso { Id = id });

            return respuesta;
        }
    }
}
