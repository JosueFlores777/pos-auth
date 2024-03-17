using Aplicacion.CommandHandlers;
using Aplicacion.Mappers;
using AutoMapper;
using Dominio.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class MapperExtension
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddTransient(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CatalogoToDtoCatalogo>();
                cfg.AddProfile<DtoRolToRol>();
                cfg.AddProfile(new DtoUsuarioToUsuarioMapper(provider.GetService<IRolRepository>()));
            cfg.AddProfile<PaginaToDtoRespuesta>();
                cfg.AddProfile<PermisoToDtoPermiso>();
                cfg.AddProfile(new UsuarioToDtoLogin(provider.GetService<IPermisoRepository>()));
                cfg.AddProfile<ImportadorToDtoImportador>();
                cfg.AddProfile<TipoProductoDtoToTipoProducto>();
            }).CreateMapper());
        }
    }

}
