using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class ModulosRol : ISpecification<Rol>
    {

        public ModulosRol()
        {
        }

        public Func<Rol, bool> Traer()
        {
            var accesos = new List<int> { Rol.IdRolUsuarioRecibo };
            return new Func<Rol, bool>(c => accesos.Contains( c.Id ));
        }

       
    }
}