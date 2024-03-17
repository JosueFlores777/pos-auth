using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class UsuarioAreaRepository : GenericRepository<UsuarioArea>, IUsuarioAreaRepository
    {
        public UsuarioAreaRepository(AutenticationContext dbContext) : base(dbContext)
        {
        }
    }
}
