using Aplicacion.Dtos;
using Aplicacion.Dtos.Importador;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories.Extensiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Mappers
{
    public class ImportadorToDtoImportador : Profile
    {
        public ImportadorToDtoImportador() 
        {
            CreateMap<IPagina<Importardor>, Metadata>();
            CreateMap<Importardor, DtoImportador>().ReverseMap();
            CreateMap<TipoProductoResponse, DtoTipoProducto>().ReverseMap();
            CreateMap<DtoTipoProducto, TipoProductoResponse>().ReverseMap();

            CreateMap<IPagina<Importardor>, DtoImportadoresPaginados>().ForMember(c => c.Metadata, f => f.MapFrom(c => Getmetadata(c)))
               .ForMember(c => c.valores, f => f.MapFrom((g, orderDto, i, context) => Mapvalores(g, context)));
        }



        private IEnumerable<DtoImportador> Mapvalores(IEnumerable<Importardor> importadores, ResolutionContext context)
        {
           
            var lista = new List<DtoImportador>();
            foreach (var item in importadores) lista.Add(context.Mapper.Map<DtoImportador>(item));
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