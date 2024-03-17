using Dominio.Models;
using System;

namespace Dominio.Especificaciones
{
    public class BuscarUsuarioPorId : ISpecification<Usuario>
    {
        private readonly int id;

        public BuscarUsuarioPorId(int  id)
        {
            this.id = id;
        }
        public Func<Usuario, bool> Traer()
        {

            return new Func<Usuario, bool>(c => c.Id == id);
        }
    }
}
