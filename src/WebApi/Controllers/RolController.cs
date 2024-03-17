
using Aplicacion.Commands.Rol;
using Aplicacion.Dtos;
using Aplicacion.Services.Comandos;
using Dominio.Especificaciones;
using Dominio.Models;
using Dominio.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        private readonly ICommandBus commandBus;
        private readonly IRolRepository rolRepository;

        public RolController(ICommandBus commandBus, IRolRepository rolRepository)
        {
            this.commandBus = commandBus;
            this.rolRepository = rolRepository;
        }


        /// <summary>
        ///  Consulta todos los roles y los devuelve paginados.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /rol
        ///
        /// </remarks>
        /// <param name="ownerParameter"></param>
        /// <returns>Lista de roles</returns>
        /// <response code="200">Lista de roles paginados</response>
        /// <response code="500">Error interno</response> 
        /// <response code="401">NO Autorizado</response>
        /// <response code="403">NO tiene permiso para ejecutar el metodo</response>
        // GET: api/rol
        [HttpGet]
        public IResponse GetRoles([FromQuery] ConsultarRoles ownerParameter)
        {
            var respuesta = commandBus.execute(ownerParameter);


            return respuesta;
        }
        /// <summary>
        /// Consulta todos los roles y los devuelve sin paginar.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Rol/sinpaginar
        ///
        /// </remarks>
        /// <returns>Lista de roles</returns>
        /// <response code="200">Lista de roles sin paginar</response>
        /// <response code="500">Error interno</response> 
        /// <response code="401">NO Autorizado</response>
        /// <response code="403">NO tiene permiso para ejecutar el metodo</response>
        [HttpGet]
        [Route("sinpaginar")]
        public IResponse ConsultarSinPaginar([FromQuery] ConsultarRolesSinPaginar consulta)
        {
            var respuesta = commandBus.execute(consulta);
            return respuesta;
        }

        /// <summary>
        /// Consulta un rol con sus permisos.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Rol/1
        ///
        /// </remarks>
        /// <returns>Rol consultado</returns>
        /// <param name="id"></param>
        /// <response code="200"></response>
        /// <response code="500">Error interno</response> 
        /// <response code="401">NO Autorizado</response>
        /// <response code="403">NO tiene permiso para ejecutar el metodo</response>
        [HttpGet("{id}", Name = "GetById")]
        public IResponse Get(int id)
        {
            var respuesta = commandBus.execute(new ConsultarRol { id = id });
            return respuesta;
        }

        /// <summary>
        /// Crea un nuevo Rol.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Rol
        ///     {
        ///     "nombre":"Rol de prueba",
        ///     "descripcion":
        ///     "rol de prueba",
        ///     "permisos":[1,8,12]
        ///     }
        ///
        /// </remarks>
        /// <param name="rol"></param>
        /// <returns>Nuevo rol creado</returns>
        /// <response code="200">Rol Creado Satisfactoriamente</response>
        /// <response code="500">Error interno</response> 
        /// <response code="401">NO Autorizado</response>
        /// <response code="403">NO tiene permiso para ejecutar el metodo</response>
        // POST: api/Rol
        [HttpPost]
        public void Post([FromBody] DtoRol rol)
        {
            commandBus.execute(new CrearRol { Rol = rol });
        }

        /// <summary>
        /// Actualiza un rol.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Rol
        ///       {
        ///       "id":1,
        ///       "nombre":"Prueba",
        ///       "descripcion":"Prueba 2",
        ///       "permisos":[1,2,8,10]
        ///       }
        ///
        /// </remarks>
        /// <returns>Rol actualizadoo</returns>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <response code="200"></response>
        /// <response code="500">Error interno</response> 
        /// <response code="401">NO Autorizado</response>
        /// <response code="403">NO tiene permiso para ejecutar el metodo</response>
        // PUT: api/rol/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DtoRol value)
        {
            commandBus.execute(new EditarRol { Rol = value, Id = id });
        }

        [HttpGet("modulos", Name = "modulos-roles")]
        public List<Rol> ModulosRoles()
        {
            return rolRepository.Filter(new ModulosRol()).ToList(); 
        }


    }
}
