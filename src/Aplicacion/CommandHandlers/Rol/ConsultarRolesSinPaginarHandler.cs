using Aplicacion.Commands.Rol;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers.Rol
{
    public class ConsultarRolesSinPaginarHandler : AbstractHandler<ConsultarRolesSinPaginar>
    {
        private readonly IRolRepository rolRepository;
        private readonly IMapper mapper;

        public ConsultarRolesSinPaginarHandler(IRolRepository rolRepository, IMapper mapper)
        {
            this.rolRepository = rolRepository;
            this.mapper = mapper;
        }

        public override IResponse Handle(ConsultarRolesSinPaginar message)
        {
            var listaDto = new List<DtoRol>();
            var lista = (message.all==true) ? rolRepository.GetAll() : rolRepository.Filter(new BuscarRolesAsignables());
            foreach (var item in lista) listaDto.Add(mapper.Map<DtoRol>(item));

            return new DtoListaRolesSinPaginar { Lista = listaDto };
        }
    }
}
