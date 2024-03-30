using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Dtos.Importador
{
   public class DtoImportador: IResponse
    {
        public string TipoImportador { get; set; }
        public int TipoIdentificadorId { get; set; }
        public int TipoPersonaId { get; set; }
        public string Nombre { get; set; }
        public int NacionalidadId { get; set; }
        public DtoCatalogo Nacionalidad { get; set; }
        public string Identificador { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int DepartamentoId { get; set; }
        public DtoCatalogo Departamento { get; set; }
        public int MunicipioId { get; set; }
        public DtoCatalogo Municipio { get; set; }
        public DtoCatalogo TipoIdentificador { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int? Id { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaEliminacion { get; set; }
        public bool CorreoEnviado { get; set; }
        public int MarcaId { get; set; }
        public DtoCatalogo Marca { get; set; }
        public int ModeloId { get; set; }
        public DtoCatalogo Modelo { get; set; }
        public int? ArchivoId { get; set; }
        public IList<ImportadorAccesosDto> Accesos { get; set; }
        public bool AccesoAprobado { get; set; }
        public bool CorreoVerificado { get; set; }
        public DateTime? FechaDenegacionAcceso { get; set; }
        public DateTime? FechaAprobacionAcceso { get; set; }
        public string MotivoRechazo { get; set; }
  
        public bool UserExist { get; set; }

    }

 
}
