using Aplicacion.Services.Validaciones;
using Dominio.Service;
using Infraestructura.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.DependencyInjection
{
    public static class TokenResolutionExtencion
    {
        public static void AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IAutenticationHelper, AutenticationHelper>();
            services.AddTransient<ITokenService, TokenService>();
            var appSettingsSection = configuration.GetSection("AppSettings");
             services.Configure<AppSettings>(appSettingsSection);

             //configure jwt authentication
             /*var appSettings = appSettingsSection.Get<AppSettings>();
             var key = Encoding.ASCII.GetBytes(appSettings.Secret);
             services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });*/



        }
    }
}
