using Dominio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Models
{
    public class Usuario : IEntity
    {
        public static string usuarioInterno = "usuario-interno";
        public static string tipoUsuarioImportador = "importador";
        public static int idUsuarioAdmin = 1;
        public static string correoUsuarioAdmin = "admin@gmail.com";
        public static List<int> PermisosUsuarioExterno = new List<int>() {25};
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string IdentificadorAcceso { get; set; }
        public bool Activo { get; set; }
        public string Contrasena { get; set; }
        public string CodigoTemporal { get; set; }
        public int? DepartamentoId { get; set; }
        public Catalogo Departamento { get; set; }

        public IList<UsuarioRol> Roles { get; set; }
        public bool CambiarContrasena { get; set; }

        public void PropietarioCambiaContrasena(string contrasena)
        {
            Contrasena = getPassword(contrasena);
            this.FechaActualizacion = DateTime.Now;
            this.CambiarContrasena = false;
        }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public DateTime? FechaRestableceContrasena { get; set; }
        public string TipoUsuario { get; set; }

        public ICollection<UsuarioRegional> UsuarioRegional { get; set; }
        public ICollection<UsuarioArea> UsuarioArea { get; set; }
        public void RestablecerContrasenaImportador(string contrasena) {
            Contrasena = getPassword(contrasena);
            FechaRestableceContrasena = DateTime.Now;
            FechaActualizacion = DateTime.Now;
            CambiarContrasena = true;
        }
        public void Enable()
        {
            Activo = true;
        }
        public void Disable()
        {
            Activo = false;
        }

        public void Inicializar(string tipoUsuario, IList<int> roles)
        {
            Enable();
            FechaRegistro = DateTime.Now;
            CambiarContrasena = true;
            Contrasena = getPassword(Contrasena);
            TipoUsuario = tipoUsuario == null ? usuarioInterno : tipoUsuario;
            CrearUsuarioRol(roles);
        }

        public void ActualizarFecha(IList<int> roles, string tipoUsuario) {
            this.FechaActualizacion = DateTime.Now;
            TipoUsuario = tipoUsuario == null ? usuarioInterno : tipoUsuario;
            CrearUsuarioRol(roles);
        }

        public static string getPassword(string constrasena)
        {
            return PasswordHelper.getPassword(constrasena);
        }
        public void CrearUsuarioRol(IList<int> permisosLista)
        {
            this.Roles = new List<UsuarioRol>();
            foreach (var item in permisosLista)
            {
                Roles.Add(new UsuarioRol { RolId = item, Usuario = this });
            }

        }

        public void AdministradorCambiaContrasena(string nombre, int? departamento, string contrasena, IList<int> roles, bool activo)
        {
            this.Nombre = nombre;
            this.Activo = activo;
            this.DepartamentoId = departamento;
            this.FechaActualizacion = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(contrasena))
            {
                Contrasena = getPassword(contrasena);
                CambiarContrasena = true;
            };
            this.CrearUsuarioRol(roles);

        }
    }
}
