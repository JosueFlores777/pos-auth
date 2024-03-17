using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Helpers
{
   public interface ICorreoHelper
    {
        void EnviarCorreoUsuarioCreado(string Usuario, string contrasena, string correoDestino);

        void EnviarCorreoParaVerificacion(string correoDestino, string tokenVerificacion);
        void EnviarCorreoParaActulizacion(string correoDestino, string tokenVerificacion,DateTime fechaActulizacion, string correoNuevo);
        void EnviarCorreoDenegacionAcceso(string correoDestino, string motivo);
        void EnviarCorreoAccesosImportador(Importardor importador);
        void EnviarCorreoRolCreado(string Usuario, string NombreRol);
        void EnviarCorreoRolEditado(string Usuario, string NombreRol);
        void EnviarCorreoModificarSolicitud(List<string> correoDestino, string motivo, string CodigoTemporal);
    }
}
