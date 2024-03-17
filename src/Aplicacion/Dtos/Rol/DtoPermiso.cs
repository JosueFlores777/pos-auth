using System.Collections.Generic;

namespace Aplicacion.Dtos
{
    public class DtoPermiso {
        public int Id { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public int? PermisoPadre { get; set; }
        public bool EsMenu { get; set; }
        public string Icono { get; set; }
        public int Orden { get; set; }
        public bool TieneHijos { get; set; }
        public IEnumerable<DtoPermiso> Hijos { get; set; }
    }
}
