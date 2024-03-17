using Dominio.Models;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;

namespace Dominio.Repositories
{
   public interface IImportadorRepository : IGenericRepository<Importardor>
    {
        Importardor GetByIdConDependencias(int id);
        IPagina<Importardor> Filter(IConsulta ownerParameters, string especificaciones);
    }
}
