using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class PermisoRepository : GenericRepository<Permiso>, IPermisoRepository
    {
        public PermisoRepository(AutenticationContext dbContext)
        : base(dbContext)
        {

        }
    }
}
