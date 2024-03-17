using Aplicacion.Services.ConsultaPermiso;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DependencyInjection
{
    public static class AplicacionServiciosExtencion
    {
        public static void AddAplicacionServices(this IServiceCollection services)
        {
            services.AddTransient<IConsultaPermisoService, ConsultaPermisoService>();

        }
    }
}
