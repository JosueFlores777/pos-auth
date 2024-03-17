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
    public class CatalogoController : ControllerBase
    {
        public ICommandBus CommandBus { get; }

        public CatalogoController(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

           
        // GET: api/Catalogo/5
        [HttpGet("{tipo}", Name = "ConsultaCatalogo")]
        public IResponse Get(string tipo)
        {
            return CommandBus.execute(new ConsultarCatalogo { Tipo = tipo, IdPadre = 0 });
        }

        // GET: api/Catalogo/5
        [HttpGet("{tipo}/id-padre/{idpadre}", Name = "ConsultaCatalogoPorPadre")]
        public IResponse Get(string tipo, int idpadre)
        {
            return CommandBus.execute(new ConsultarCatalogo { Tipo = tipo, IdPadre = idpadre });
        }
    }
}
