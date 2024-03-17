using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarImportadoresConCorreoVerificado : ISpecification<Importardor>
    {
        public Func<Importardor, bool> Traer()
        {
            return new Func<Importardor, bool>(c => c.CorreoVerificado==true && c.FechaAprobacionAcceso==null );
        }
    }
}
