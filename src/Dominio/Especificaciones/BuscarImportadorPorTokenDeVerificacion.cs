using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarImportadorPorTokenDeVerificacion : ISpecification<Importardor>
    {
        private readonly string token;

        public BuscarImportadorPorTokenDeVerificacion(string token)
        {
            this.token = token;
        }

        public Func<Importardor, bool> Traer()
        {
            return new Func<Importardor, bool>(c => c.TokenVerificacion == token);

        }
    }
}
