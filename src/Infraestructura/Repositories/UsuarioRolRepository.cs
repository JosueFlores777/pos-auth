using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class UsuarioRolRepository : GenericRepository<UsuarioRol>, IUsuarioRolRepository
    {
        public UsuarioRolRepository(AutenticationContext dbContext) : base(dbContext)
        {
        }
    }
}
