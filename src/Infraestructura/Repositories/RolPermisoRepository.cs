using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class RolRepository : GenericRepository<RolPermiso>, IRolPermisoRepository
    {
        public RolRepository(AutenticationContext dbContext) : base(dbContext)
        {
        }
    }
}
