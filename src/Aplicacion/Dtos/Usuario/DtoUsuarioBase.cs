using System;
using System.Collections.Generic;

namespace Aplicacion.Dtos.Usuario
{
    public class DtoUsuarioBase
    {
        public int? DepartamentoId { get; set; }
        public string DepartamentoNombre { get; set; }
        public IList<DtoRol> Roles { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string IdentificadorAcceso { get; set; }
        public bool Activo { get; set; }
        public bool CambiarContrasena { get; set; }

        public string CodigoTemporal { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public ICollection<DtoUsuarioRegional> UsuarioRegional { get; set; }
        public ICollection<DtoUsuarioArea> UsuarioArea { get; set; }

    }

}
