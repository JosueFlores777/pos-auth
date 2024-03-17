using Dominio.Models;
using Dominio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Infraestructura.Service
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings appSettings;
        private readonly IDistributedCache cache;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TokenService(IOptions<AppSettings> appSettings, IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
        {
            this.appSettings = appSettings.Value;
            this.cache = cache;
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetIdentificadorUsuario()
        {
            var clain = GetToken().Claims.Where(c => c.Type == "email").FirstOrDefault();
            return clain.Value;
        }


        public string CrearOtraerToken(Usuario usuario)
        {
            var tokenCreado = TarerTokenSiExiste(usuario.Id);
            if (!string.IsNullOrWhiteSpace(tokenCreado)) return tokenCreado;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.IdentificadorAcceso.Trim()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Surname, ""),
                }),
                Expires = DateTime.UtcNow.AddHours(appSettings.TokenTiempoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var obj = new CacheObj { Token = tokenHandler.WriteToken(token), Permisos = this.GerPermisos(usuario) };

            byte[] encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(appSettings.TokenTiempoHoras));

            var id =  usuario.Id.ToString();
            cache.Set(id, encodedCurrentTimeUTC, options);
            return tokenHandler.WriteToken(token);
        }
        
        public List<Permiso> TraerPermisos()
        {
          
            var cahe = cache.Get(GetIdCache());
            if (cahe != null) return  GetObj(cahe).Permisos;
            return new List<Permiso>();
        }

        public bool VerificarToken()
        {
            var objArray = cache.Get(this.GetIdCache());
            if (objArray != null)
                return GetObj(objArray).Token.Equals(TraerTokenDeRequest());
            return false;
        }

        private CacheObj GetObj(byte[] cahe) {
            var json = Encoding.Default.GetString(cahe);
            var obj = JsonConvert.DeserializeObject<CacheObj>(json);
            return obj;
        }
        private List<Permiso> GerPermisos(Usuario usuario)
        {
            var permisos = new List<Permiso>();
            foreach (var roles in usuario.Roles)
            {
                foreach (var permiso in roles.Rol.Permisos)
                {
                    permisos.Add(permiso.Permiso);
                }
            }
            return permisos;
        }


        private JwtSecurityToken GetToken()
        {
         
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(TraerTokenDeRequest());
        }


        public string TraerTokenDeRequest()
        {
            var tokens= httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            return tokens.Replace("Bearer ", "");

        }

        public int GetIdUsuario()
        {
                var clain = GetToken().Claims.Where(c => c.Type == "nameid").FirstOrDefault();
                return int.Parse(clain.Value);
       
        }

        public void EliminarToken()
        {
            cache.Remove(GetIdCache());
        }
        private string GetIdCache()
        {

            var tokeLeido = GetToken();
            var id = tokeLeido.Claims.Where(c => c.Type == "nameid").FirstOrDefault().Value;
            return id;
        }

        public string TarerTokenSiExiste(int usuarioId)
        {
            var id = usuarioId.ToString();
            var objArray = cache.Get(id);
            if (objArray == null) {
                return null;
            }
            return GetObj(objArray).Token;
        }


    }
}

namespace Infraestructura.Service
{
    public class CacheObj
    {
        public string Token { get; set; }
        public List<Permiso> Permisos { get; set; }

    }
}