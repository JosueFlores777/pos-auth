using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
   public class BuscarImportadorConCorreoEnviado : ISpecification<Cliente>
    {
        private readonly int id;

        public BuscarImportadorConCorreoEnviado(int id) {
            this.id = id;
        }
        public Func<Cliente, bool> Traer()
        {
            return new Func<Cliente, bool>(c => c.Id == id && c.CorreoEnviado==true);
        }
    }
}
