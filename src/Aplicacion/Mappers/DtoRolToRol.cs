using Aplicacion.Commands;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Mappers
{
    public class DtoRolToRol : Profile
    {
        public DtoRolToRol()
        {
            CreateMap<Rol, DtoRol>()
            .ForMember(c => c.Permisos, opt => opt.MapFrom(c => perimisos(c.Permisos)))

              .ForMember(C => C.Id, F => F.MapFrom(X => X.Id));

            CreateMap<DtoRol, Rol>().ForMember(c => c.Permisos, opt => opt.Ignore());


        }

        public IList<int> perimisos(IList<RolPermiso> permisos)
        {

            var permisosCol = new List<int>();
            if(permisos!=null)foreach (var item in permisos)permisosCol.Add(item.PermisoId);
            
            return permisosCol;
        }

    }
}
