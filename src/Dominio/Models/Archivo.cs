using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Archivo: IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public string PathFisico { get; set; }
        public string ContentType { get; set; }
        public string Indentificador { get; set; }
        public int? UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}
