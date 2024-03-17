using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarRolesAsignables : ISpecification<Rol>
    {

        public BuscarRolesAsignables()
        {
        }
      

        Func<Rol, bool> ISpecification<Rol>.Traer()
        {
            return new Func<Rol, bool>(c => c.Asignable == true);
        }
    }
}