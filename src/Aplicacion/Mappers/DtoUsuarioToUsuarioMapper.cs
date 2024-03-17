using Aplicacion.Commands;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Mappers
{
    public class DtoUsuarioToUsuarioMapper : Profile
    {
        private readonly IRolRepository rolRepository;
        public DtoUsuarioToUsuarioMapper(IRolRepository rolRepository)
        {
            CreateMap<DtoUsuarioResponse, Usuario>().ForMember(c => c.Roles, f => f.Ignore());
            CreateMap<UsuarioRegional, DtoUsuarioRegional>().ReverseMap();
            CreateMap<DtoUsuarioRegional, UsuarioRegional>().ReverseMap();
            CreateMap<UsuarioArea, DtoUsuarioArea>().ReverseMap();
            CreateMap<DtoUsuarioArea, UsuarioArea>().ReverseMap();
            CreateMap<DtoUsuario, Usuario>().ForMember(c => c.Roles, f => f.Ignore());
            CreateMap<Usuario, DtoUsuarioResponse>().ForMember(c => c.Roles, f => f.MapFrom(p=>getRoles(p.Roles)));
            this.rolRepository = rolRepository;
        }

        public IList<DtoRol> getRoles(IList<UsuarioRol> usuarioRol) {
            var respuesta = new List<DtoRol>();
            foreach (var item in usuarioRol)
            {
                var rol = rolRepository.GetByIdConPermisos(item.RolId);
                respuesta.Add(new DtoRol { Id=item.RolId,Descripcion= rol.Nombre});
            }
            return respuesta;
        }
    }
}
