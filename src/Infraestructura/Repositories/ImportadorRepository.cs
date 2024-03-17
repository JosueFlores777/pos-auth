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
    public class ImportadorRepository : GenericRepository<Importardor>, IImportadorRepository
    {
        private readonly AutenticationContext dbContext;

        public ImportadorRepository(AutenticationContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IPagina<Importardor> Filter(IConsulta ownerParameters, string especificaciones)
        {
            return PagedList<Importardor>.ToPagedList(dbContext.Set<Importardor>()
                  .Where(especificaciones),
                      ownerParameters.PageNumber,
                      ownerParameters.PageSize);
        }
        public Importardor GetByIdConDependencias(int id)
        {
            return dbContext.Set<Importardor>().AsNoTracking().
                Include(c=>c.Departamento).Include(c=>c.Municipio).Include(c=>c.Nacionalidad).
                FirstOrDefault("Id="+id);
        }
    }
}
