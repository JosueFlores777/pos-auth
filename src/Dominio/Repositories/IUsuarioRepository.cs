using Dominio.Especificaciones;
using Dominio.Models;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositories
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        IPagina<Usuario> ConsultarPaginadoConRol(IConsulta ownerParameters, ISpecification<Usuario> busqueda);
        IPagina<Usuario> ConsultarPaginadoConRol(IConsulta ownerParameters);
        Usuario GetByIdConRoles(int id);

        Usuario GetUsuarioConRolPermiso(ISpecification<Usuario> busqueda);
        
    }
}
