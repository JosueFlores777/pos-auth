using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarPermisosAsignables : ISpecification<Permiso>
    {
        
        public BuscarPermisosAsignables()
        {
        }
      

        Func<Permiso, bool> ISpecification<Permiso>.Traer()
        {
            return new Func<Permiso, bool>(c => c.Asignable == true);
        }
    }
}