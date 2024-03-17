using Dominio.Models;
using Dominio.Utilities;
using System;

namespace Dominio.Especificaciones
{
    public class BuscarUsuarioPorIdentificador : ISpecification<Usuario>
    {
        private readonly string identificador;

        public BuscarUsuarioPorIdentificador(string identificador)
        {
            this.identificador = identificador;
        }
        public Func<Usuario, bool> Traer()
        {
            if (RegexUtilities.IsValidEmail(identificador))
            {
                return new Func<Usuario, bool>(c => c.IdentificadorAcceso.ToLower().Trim() == identificador.ToLower().Trim());
            }
            else {
                return new Func<Usuario, bool>(c => c.IdentificadorAcceso.Replace("-","").Trim() == identificador.Replace("-","").Trim());
            }
                
        }
    }
}
