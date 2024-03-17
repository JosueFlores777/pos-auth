using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
   public class BuscarImportadorConCorreoEnviado : ISpecification<Importardor>
    {
        private readonly int id;

        public BuscarImportadorConCorreoEnviado(int id) {
            this.id = id;
        }
        public Func<Importardor, bool> Traer()
        {
            return new Func<Importardor, bool>(c => c.Id == id && c.CorreoEnviado==true);
        }
    }
}
