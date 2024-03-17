using Dominio.Models;
using Dominio.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarUsuarioPorIdentificadorYCodigo : ISpecification<Usuario>
    {
        private readonly string identificador;
        private readonly string codigo;

        public BuscarUsuarioPorIdentificadorYCodigo(string identificador, string codigo)
        {
            this.identificador = identificador;
            this.codigo = codigo;
        }
        public Func<Usuario, bool> Traer()
        {
            if (RegexUtilities.IsValidEmail(identificador))
            {
                return new Func<Usuario, bool>(c => c.IdentificadorAcceso.ToLower().Trim() == this.identificador.ToLower().Trim() && c.CodigoTemporal == codigo);
            }
            else {
                return new Func<Usuario, bool>(c => c.IdentificadorAcceso.Replace("-", "").Trim() == this.identificador.Replace("-", "").Trim() && c.CodigoTemporal == codigo);
            }
        
        }
    }
}
