using Dominio.Models;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;

namespace Dominio.Repositories
{
   public interface IImportadorRepository : IGenericRepository<Cliente>
    {
        Cliente GetByIdConDependencias(int id);
        IPagina<Cliente> Filter(IConsulta ownerParameters, string especificaciones);
    }
}
