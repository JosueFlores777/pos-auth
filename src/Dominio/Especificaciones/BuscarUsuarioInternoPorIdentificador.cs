using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarUsuarioInternoPorIdentificador : ISpecification<Usuario>
    {
        private readonly string correo;

        public BuscarUsuarioInternoPorIdentificador(string correo)
        {
            this.correo = correo;
        }
        public Func<Usuario, bool> Traer()
        {

            return new Func<Usuario, bool>(c => c.IdentificadorAcceso == correo && c.TipoUsuario==Usuario.usuarioInterno);
        }
    }
}
