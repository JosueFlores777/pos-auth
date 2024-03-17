using Dominio.Models;
using System;

namespace Dominio.Especificaciones
{
    public class ConsultarCatalogoPorTipoYPadre : ISpecification<Catalogo>
    {
        private readonly string tipo;
        private readonly int idPadre;

        public ConsultarCatalogoPorTipoYPadre(string tipo, int idPadre) {
            this.tipo = tipo;
            this.idPadre = idPadre;
        }
        public Func<Catalogo, bool> Traer()
        {
            return new Func<Catalogo, bool>(c => c.Tipo == tipo && c.IdPadre == idPadre);
        }
    }
}
