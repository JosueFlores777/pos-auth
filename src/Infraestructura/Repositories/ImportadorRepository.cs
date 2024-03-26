using Dominio.Models;
using Dominio.Repositories;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;
using Infraestructura.Data;
using Infraestructura.Repositories.Extenciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace Infraestructura.Repositories
{
    public class ImportadorRepository : GenericRepository<Cliente>, IImportadorRepository
    {
        private readonly AutenticationContext dbContext;

        public ImportadorRepository(AutenticationContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IPagina<Cliente> Filter(IConsulta ownerParameters, string especificaciones)
        {
            return PagedList<Cliente>.ToPagedList(dbContext.Set<Cliente>()
                  .Where(especificaciones),
                      ownerParameters.PageNumber,
                      ownerParameters.PageSize);
        }
        public Cliente GetByIdConDependencias(int id)
        {
            return dbContext.Set<Cliente>().AsNoTracking().
                Include(c=>c.Departamento).Include(c=>c.Municipio).Include(c=>c.Nacionalidad).
                FirstOrDefault("Id="+id);
        }
    }
}
