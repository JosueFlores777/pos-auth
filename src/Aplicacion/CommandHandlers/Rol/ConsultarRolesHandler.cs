using Aplicacion.Commands.Rol;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using Dominio.Repositories.Extensiones;
using System.Collections.Generic;

namespace Aplicacion.CommandHandlers.Rol
{
    public class ConsultarRolesHandler : AbstractHandler<ConsultarRoles>
    {
        private readonly IRolRepository rolRepository;
        private readonly IMapper mapper;

        public ConsultarRolesHandler(IRolRepository rolRepository, IMapper mapper)
        {
            this.rolRepository = rolRepository;
            this.mapper = mapper;
        }
        public override IResponse Handle(ConsultarRoles message)
        {

            if (message.Nombre != null)
            {
                var respuestaFiltrada = rolRepository.ConsultarPaginado(message, new BuscarRolPorNombre(message.Nombre));
                return mapper.Map<RolPaginado>(respuestaFiltrada);
            }

            var respuesta = rolRepository.ConsultarPaginado(message,new BuscarRolesAsignables());
            return mapper.Map<RolPaginado>(respuesta);


        }
    }
}
