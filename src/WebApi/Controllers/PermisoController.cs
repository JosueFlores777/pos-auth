using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Commands;
using Aplicacion.Dtos;
using Aplicacion.Services.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        public PermisoController(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

        public ICommandBus CommandBus { get; }

        // GET: api/Permiso
        [HttpGet]
        public IResponse Get()
        {
            return CommandBus.execute(new ConsultarPermisos());
        }
    }
}
