using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models.Regla
{
    public interface ICambioPassword : IRegla
    {
        IReglaRespuesta verificarPasswor(int idUsuario, string passwor);
    }

    public interface IReglaRespuesta { 
        bool Cumple { get; set; }
    }

    public class RegalRespuestaBasica : IReglaRespuesta
    {
        public bool Cumple { get; set; }
    }
}
