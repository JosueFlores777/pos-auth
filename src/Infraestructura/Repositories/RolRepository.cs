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
    public class RolPermisoRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly AutenticationContext dbContext;

        public RolPermisoRepository(AutenticationContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

      

        public Rol GetByIdConPermisos(int id)
        {
            return dbContext.Set<Rol>().AsNoTracking().Include(c => c.Permisos).FirstOrDefault(e => e.Id == id); ;
        }
    }
}
