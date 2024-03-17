using Dominio.Repositories;
using Dominio.Service;
using Infraestructura.Data;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace WebApi.DependencyInjection
{
    public static class ContextrExtensions
    {
        public static void AddContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AutenticationContext>(
         options =>
         {
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            // options.EnableSensitiveDataLogging();
         });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.Scan(scan => scan.FromAssemblyOf<UsuarioRepository>().AddClasses(classes => classes.AssignableTo(typeof(IGenericRepository<>))).AsImplementedInterfaces().WithScopedLifetime());


            // services.AddScoped<IUsuarioRepository, UsuarioRepository>();


        }
    }
}
