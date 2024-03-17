using System.Collections.Generic;

namespace Aplicacion.Dtos.Usuario
{
    public class DtoUsuarioResponse : DtoUsuarioBase, IResponse
    {
        public string DepartamentoDescripcion { get; set; }
    }

}
