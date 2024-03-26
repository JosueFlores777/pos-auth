using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarImportadoresConCorreoVerificado : ISpecification<Cliente>
    {
        public Func<Cliente, bool> Traer()
        {
            return new Func<Cliente, bool>(c => c.CorreoVerificado==true && c.FechaAprobacionAcceso==null );
        }
    }
}
