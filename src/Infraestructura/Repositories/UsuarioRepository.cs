using Dominio.Especificaciones;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;
using Infraestructura.Data;
using Infraestructura.Repositories.Extenciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly AutenticationContext dbContext;

        public UsuarioRepository(AutenticationContext dbContext)
        : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IPagina<Usuario> ConsultarPaginadoConRol(IConsulta ownerParameters, ISpecification<Usuario> busqueda)
        {
            return PagedList<Usuario>.ToPagedList(dbContext.Set<Usuario>().OrderBy(on => on.Id).Include("Roles.Rol").Include(c => c.Departamento).Where(busqueda.Traer()).AsQueryable(),
                    ownerParameters.PageNumber,
                    ownerParameters.PageSize);
        }


        public IPagina<Usuario> ConsultarPaginadoConRol(IConsulta ownerParameters)
        {
            return PagedList<Usuario>.ToPagedList(dbContext.Set<Usuario>().OrderBy(on => on.Id).Include("Roles.Rol").Include(c => c.Departamento).Where(c=>c.TipoUsuario==Usuario.usuarioInterno),
                        ownerParameters.PageNumber,
                        ownerParameters.PageSize);
        }

        public Usuario GetByIdConRoles(int id)
        {
            return dbContext.Set<Usuario>().AsNoTracking().Include("Roles.Rol").Include(c=>c.UsuarioRegional).Include(c => c.UsuarioArea).FirstOrDefault(e => e.Id == id);
        }

        public Usuario GetUsuarioConRolPermiso(ISpecification<Usuario> busqueda)
        {
           return dbContext.Set<Usuario>().AsNoTracking().Include("Roles.Rol.Permisos.Permiso").Include(c => c.Departamento).Include(c=> c.UsuarioArea).Include(c => c.UsuarioRegional).FirstOrDefault(busqueda.Traer());
        }
    }
    
}
