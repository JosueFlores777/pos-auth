using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Especificaciones
{
   public class BuscarUsuarioPorNombreYCorreo : ISpecification<Usuario>
    {
        private readonly string nombre;
        private readonly string correo;
        private readonly int idDepartamento;
        public BuscarUsuarioPorNombreYCorreo(string nombre, string correo,int idDepartamento)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.idDepartamento = idDepartamento;
        }
        public Func<Usuario, bool> Traer()
        {
            Func<Usuario, bool> expresionA = null;
            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(correo) && idDepartamento !=0) expresionA = new Func<Usuario, bool>(c => c.Nombre.ToLower().Contains(nombre.ToLower()) && c.IdentificadorAcceso.Contains(correo)&& c.DepartamentoId.ToString().Contains((idDepartamento.ToString())) && c.TipoUsuario == Usuario.usuarioInterno);

            else if ( !string.IsNullOrWhiteSpace(correo) && idDepartamento != 0) expresionA = new Func<Usuario, bool>(c =>  c.IdentificadorAcceso.Contains(correo) && c.DepartamentoId.ToString().Contains((idDepartamento.ToString())) && c.TipoUsuario == Usuario.usuarioInterno);
            else if (!string.IsNullOrWhiteSpace(nombre)  && idDepartamento != 0) expresionA = new Func<Usuario, bool>(c => c.Nombre.ToLower().Contains(nombre.ToLower())  && c.DepartamentoId.ToString().Contains((idDepartamento.ToString())) && c.TipoUsuario == Usuario.usuarioInterno);
            else if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(correo)) expresionA = new Func<Usuario, bool>(c => c.Nombre.ToLower().Contains(nombre.ToLower()) && c.IdentificadorAcceso.Contains(correo)  && c.TipoUsuario == Usuario.usuarioInterno);

            else if (!string.IsNullOrWhiteSpace(nombre)) expresionA = new Func<Usuario, bool>(c=>c.Nombre.ToLower().Contains(nombre.ToLower()) && c.TipoUsuario == Usuario.usuarioInterno);
            else if (!string.IsNullOrWhiteSpace(correo)) expresionA = new Func<Usuario, bool>(c => c.IdentificadorAcceso.Contains(correo) && c.TipoUsuario == Usuario.usuarioInterno);
            else if (idDepartamento != 0) expresionA = new Func<Usuario, bool>(c => c.DepartamentoId.ToString().Contains((idDepartamento.ToString())) && c.TipoUsuario == Usuario.usuarioInterno);
            return expresionA;        
        }
    }

  
}
