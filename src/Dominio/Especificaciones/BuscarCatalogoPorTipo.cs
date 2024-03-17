using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Especificaciones
{
    public class BuscarCatalogoPorTipo : ISpecification<Catalogo>
    {
        private readonly string tipo;

        public BuscarCatalogoPorTipo(string tipo) {
            this.tipo = tipo;
        }
        public Func<Catalogo, bool> Traer()
        {

            return new Func<Catalogo, bool>(c => c.Tipo == tipo);
        }
    }
}
