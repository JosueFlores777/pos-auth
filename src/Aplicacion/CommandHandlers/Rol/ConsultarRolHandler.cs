using Aplicacion.Commands.Rol;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Rol
{
    public class ConsultarRolHandler : AbstractHandler<ConsultarRol>
    {
        private readonly IRolRepository rolrepository;
        private readonly IMapper mapper;

        public ConsultarRolHandler(IRolRepository rolrepository, IMapper mapper)
        {
            this.rolrepository = rolrepository;
            this.mapper = mapper;
        }
        public override IResponse Handle(ConsultarRol message)
        {
            var rol = rolrepository.GetByIdConPermisos(message.id);
            return mapper.Map<DtoRol>(rol);

        }
    }
}
