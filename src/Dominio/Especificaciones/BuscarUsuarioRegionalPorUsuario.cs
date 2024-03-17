using Dominio.Models;
using System;

namespace Dominio.Especificaciones
{
    public class BuscarUsuarioRegionalPorUsuario : ISpecification<UsuarioRegional>
    {
        private readonly int idUsuarioRegional;
        public BuscarUsuarioRegionalPorUsuario(int idUsuarioRegional)
        {
            this.idUsuarioRegional = idUsuarioRegional;
        }
        public Func<UsuarioRegional, bool> Traer()
        {
            return new Func<UsuarioRegional, bool>(c => c.UsuarioId == idUsuarioRegional);
        }
    }
}
