using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class UsuarioRegionalRepository : GenericRepository<UsuarioRegional>, IUsuarioRegionalRepository
    {
        public UsuarioRegionalRepository(AutenticationContext dbContext) : base(dbContext)
        {
        }
    }
}
