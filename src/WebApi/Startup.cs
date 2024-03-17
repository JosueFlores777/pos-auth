
using Aplicacion.Exceptions;
using Dominio.Helpers;
using Dominio.Models.Regla;
using FluentMigrator.Runner;
using Infraestructura.Configuration;
using Infraestructura.Data;
using Infraestructura.Filters;
using Infraestructura.Migrations;
using Infraestructura.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Mail;
using WebApi.DependencyInjection;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHandlers();
            services.AddContextConfiguration(Configuration);
            services.AddMappers();
            services.AddScoped<UnitOfWordFilter>();
            services.AddAplicacionServices();
            services.AddTokenConfiguration(Configuration);
            services.AddHttpContextAccessor();
            services.AddRedis(Configuration);
            services.AddCorsConfig();
            services.AddSwaggerConf();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.Scan(scan => scan.FromAssemblyOf<CambioPassword>().AddClasses(classes => classes.AssignableTo(typeof(IRegla))).AsImplementedInterfaces().WithTransientLifetime());


            services.AddTransient<ICorreoHelper, CorreoHelper>();
            services.AddMail();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(UnitOfWordFilter));
            });

            services.AddFluentMigratorCore()
               .ConfigureRunner(rb => rb
                   .AddSqlServer()
                   .WithGlobalConnectionString(Configuration.GetConnectionString("DefaultConnection"))
                   .ScanIn(typeof(FirstMigrations).Assembly).For.Migrations());
            
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            else
            {

                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpException();
            app.UseRouting();

            //sapp.UseAuthorization();

            /* app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              });*/
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/alpha/swagger.json", "Documentacion Sistema de Pagos");
                // c.RoutePrefix = string.Empty;
            });
            app.UseCors("ApiCorsPolicy");
            app.UseMvc();
            using var scope = app.ApplicationServices.CreateScope();
            UpdateDatabase(scope.ServiceProvider);

        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AutenticationContext>();
            //context.Database.Migrate();
            //var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

           // runner.Rollback(1);
           //runner.MigrateUp();
        }
    }
}
