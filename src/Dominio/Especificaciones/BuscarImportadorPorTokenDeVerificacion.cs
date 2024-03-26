using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarImportadorPorTokenDeVerificacion : ISpecification<Cliente>
    {
        private readonly string token;

        public BuscarImportadorPorTokenDeVerificacion(string token)
        {
            this.token = token;
        }

        public Func<Cliente, bool> Traer()
        {
            return new Func<Cliente, bool>(c => c.TokenVerificacion == token);

        }
    }
}
