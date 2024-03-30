using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Models
{
    public class Cliente : IEntity
    {
        public static string TipoIngresoManual = "manual";

        public int Id { get; set; }
        public int TipoIdentificadorId { get; set; }
        public Catalogo TipoIdentificador { get; set; }
        public string Identificador { get; set; }
        public int TipoPersonaId { get; set; }
        public Catalogo TipoPersona { get; set; }
        public string Nombre { get; set; }
        public int NacionalidadId { get; set; }
        public Catalogo Nacionalidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int DepartamentoId { get; set; }
        public Catalogo Departamento { get; set; }
        public int MunicipioId { get; set; }
        public Catalogo Municipio { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int? ArchivoId { get; set; }
        public Archivo Archivo { get; set; }
        public int MarcaId { get; set; }
        public Catalogo Marca { get; set; }
        public int ModeloId { get; set; }
        public Catalogo Modelo { get; set; }
        public string TipoIngreso { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool CorreoEnviado { get; set; }
        public DateTime? FechaEnvioCorreo { get; set; }
        public bool CorreoVerificado { get; set; }
        public DateTime? FechaVerificacionCorreo { get; set; }
        public bool AccesoAprobado { get; set; }
        public DateTime? FechaAprobacionAcceso { get; set; }
        public int? UsuarioGentionId { get; set; }
        public Usuario UsuarioGention { get; set; }
        public string TokenVerificacion { get; set; }
        public string MotivoRechazo { get; set; }

        public void SolicitarAcceso() {
            FechaRegistro = DateTime.Now;
            TokenVerificacion = Guid.NewGuid().ToString();
            AccesoAprobado = false;
            CorreoVerificado = false;
            TipoIngreso = "WEB";
        }

        public void AmpliarAccesos(List<TipoProductoResponse> listaNueva, List<TipoProductoResponse> listaVieja)
        {
            TipoIngreso = "WEB";
            CorreoVerificado = false;
            FechaAprobacionAcceso = null;
            foreach (var productosV in listaVieja)
            {
                foreach (var productosN in listaNueva)
                {
                    if (productosV.Id == productosN.Id && productosV.IsChecked == true && productosN.IsChecked == false) {
                        productosN.IsChecked = true;
                    }
                } 
            }


            FechaEnvioCorreo = DateTime.Now;
            FechaModificacion = DateTime.Now;
        }
        public void DenegarAcceso(int usuarioDeniega, string motivoRechazo) {
            UsuarioGentionId = usuarioDeniega;
            FechaModificacion = DateTime.Now;
            AccesoAprobado = false;
            MotivoRechazo = motivoRechazo;
        }
        public void ActulizarImportador(Cliente imporN)
        {
            this.MunicipioId = imporN.MunicipioId;
            this.DepartamentoId = imporN.DepartamentoId;
            this.Celular = imporN.Celular;
            this.Telefono = imporN.Telefono;
            this.Correo = imporN.Correo;
            this.Direccion =  imporN.Direccion;
            FechaModificacion = DateTime.Now;
           
        }
  
        public void GestionarAcceso() {
            FechaAprobacionAcceso = DateTime.Now;
            FechaModificacion = DateTime.Now;

        }
        public void VerificarCorreo() {
            FechaModificacion = DateTime.Now;
            CorreoVerificado = true;
            FechaVerificacionCorreo = DateTime.Now;
            FechaModificacion = DateTime.Now;
        }
        public void FinalizarEnvitacion(int usuarioApruebaAcceso, List<int> accesos)
        {
            CorreoEnviado = true;
            FechaAprobacionAcceso = DateTime.Now;
            AccesoAprobado = true;
            FechaEnvioCorreo = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioGentionId = usuarioApruebaAcceso;
        }

       
    }
}
