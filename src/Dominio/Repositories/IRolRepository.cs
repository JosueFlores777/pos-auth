using Dominio.Especificaciones;
using Dominio.Models;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;

namespace Dominio.Repositories
{
    public interface IRolRepository:IGenericRepository<Rol>
    {
        Rol GetByIdConPermisos(int id);
    }
}
