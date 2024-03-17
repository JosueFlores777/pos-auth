using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
   public class Rol:IEntity
    {

        public static int IdRolUsuarioRecibo= 2;
        public static int IdRolAdministracionSistema = 1;


        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public IList<RolPermiso> Permisos { get; set; }
        public bool Asignable { get; set; }

        public void CrearRolPermiso(IList<int> permisosLista) {
            this.Permisos = new List<RolPermiso>();
            foreach (var item in permisosLista)
            {
                Permisos.Add(new RolPermiso { PermisoId=item,Rol=this});
            }
           
        }
        public void setFechaCreacion() {
            this.FechaCreacion = DateTime.Now;
        }

        public void limpiaPermisos()
        {
            this.Permisos = new List<RolPermiso>();
        }

        public void actualizar(string nombre, string descripcion, IList<int> permisos)
        {
            this.Nombre=nombre ;
            this.Descripcion = descripcion;
            this.FechaActualizacion = DateTime.Now;
            this.CrearRolPermiso(permisos);
        }
    }
}
