using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aplicacion.Mappers
{
    public class PaginaToDtoRespuesta : Profile
    {
        public PaginaToDtoRespuesta()
        {
            CreateMap<IPagina<Rol>, RolPaginado>().ForMember(c => c.Metadata, f => f.MapFrom(c => Getmetadata(c)))
                .ForMember(c => c.valores, f => f.MapFrom(g => g));
            CreateMap<IPagina<Usuario>, DtoUsuariosPaginados>().ForMember(c => c.Metadata, f => f.MapFrom(c => Getmetadata(c)))
               .ForMember(c => c.valores, f => f.MapFrom(g => Mapvalores(g)));

        }

        private IEnumerable<DtoUsuarioResponse> Mapvalores(IEnumerable<Usuario> usuarios)
        {
            var lista = new List<DtoUsuarioResponse>();
            foreach (var item in usuarios)
            {
                var roles = new List<DtoRol>();
                foreach (var rol in item.Roles)
                {
                    roles.Add(new DtoRol { Id = rol.Id, Nombre = rol.Rol.Nombre });
                }
                lista.Add(new DtoUsuarioResponse { CambiarContrasena = item.CambiarContrasena, 
                    Activo = item.Activo, IdentificadorAcceso = item.IdentificadorAcceso, Id = item.Id,
                    Nombre=item.Nombre,DepartamentoId=item.DepartamentoId,
                    DepartamentoDescripcion = item.Departamento!=null ? item.Departamento.Nombre : "",
                    Roles = roles,FechaRegistro=item.FechaRegistro, TipoUsuario=item.TipoUsuario
                });
            }
            return lista;
        }
        private Metadata Getmetadata<T>(IPagina<T> paging)
        {
            var metada = new Metadata
            {
                CurrentPage = paging.CurrentPage,
                HasPrevious = paging.HasPrevious,
                PageSize = paging.PageSize,
                TotalCount = paging.TotalCount,
                TotalPages = paging.TotalPages,
                HasNext = paging.HasNext
            };
            return metada;
        }
    }
}
