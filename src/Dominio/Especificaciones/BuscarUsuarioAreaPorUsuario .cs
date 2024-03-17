using Dominio.Models;
using System;

namespace Dominio.Especificaciones
{
    public class BuscarUsuarioAreaPorUsuario : ISpecification<UsuarioArea>
    {
        private readonly int idUsuarioArea;
        public BuscarUsuarioAreaPorUsuario(int idUsuarioArea)
        {
            this.idUsuarioArea = idUsuarioArea;
        }
        public Func<UsuarioArea, bool> Traer()
        {
            return new Func<UsuarioArea, bool>(c => c.UsuarioId == idUsuarioArea);
        }
    }
}
