using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarImportadorPorIdentificador : ISpecification<Cliente>
    {
      
        private readonly string identificador;

        public BuscarImportadorPorIdentificador(string identificador)
        {
           
            this.identificador = identificador;
        }

        public Func<Cliente, bool> Traer()
        {
            return new Func<Cliente, bool>(c =>  c.Identificador.Replace("-", "").Trim() == identificador.Replace("-", "").Trim());

        }
    }
}
