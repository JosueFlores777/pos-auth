using Aplicacion.Dtos.Importador;
using AutoMapper;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Mappers
{
   public class TipoProductoDtoToTipoProducto : Profile
    {
        public TipoProductoDtoToTipoProducto()
        {
            CreateMap<DtoTipoProducto, TipoProductoResponse>().ReverseMap();
            CreateMap<TipoProductoResponse, DtoTipoProducto>().ReverseMap();
        }

    }
}
