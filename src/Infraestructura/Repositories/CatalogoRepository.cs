using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class CatalogoRepository : GenericRepository<Catalogo>, ICatalogoRepository
    {
        public CatalogoRepository(AutenticationContext dbContext) : base(dbContext)
        {
        }
    }
}
