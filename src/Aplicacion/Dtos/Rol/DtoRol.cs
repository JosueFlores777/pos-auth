using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Dtos
{
    public class DtoRol:IResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public DateTime FehchaCreacion { get; set; }
        public IList<int> Permisos { get; set; }
        public IList<DtoPermiso> PermisosConMetadata { get; set; }
    }
}
