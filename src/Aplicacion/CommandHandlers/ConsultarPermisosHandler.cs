using Aplicacion.Commands;
using Aplicacion.Dtos;
using Aplicacion.Services.ConsultaPermiso;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.CommandHandlers
{
    public class ConsultarPermisosHandler : AbstractHandler<ConsultarPermisos>
    {
        private readonly IMapper mapper;
        private readonly IPermisoRepository permisosRepo;
        private readonly IConsultaPermisoService consultarPermisoService;

        public ConsultarPermisosHandler(IMapper mapper, IPermisoRepository permisorepo, IConsultaPermisoService consultarPermisoService) {
            this.mapper = mapper;
            this.permisosRepo = permisorepo;
            this.consultarPermisoService = consultarPermisoService;
        }
        public override IResponse Handle(ConsultarPermisos message)
        {
            var permisos = permisosRepo.Filter(new BuscarPermisosAsignables());
            IList < DtoPermiso > dtoPermiso= new List<DtoPermiso>();
            foreach (var item in permisos)
                dtoPermiso.Add(mapper.Map<DtoPermiso>(item));
            return new DtoPermisos { Permisos = consultarPermisoService.Estructurar(dtoPermiso) };
        }
    }
}
