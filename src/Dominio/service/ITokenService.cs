using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Service
{
   public interface ITokenService
    {
        string CrearOtraerToken(Usuario usuario);
        string TarerTokenSiExiste(int usuarioId);
        void EliminarToken();
        string TraerTokenDeRequest();
        bool VerificarToken();

        string GetIdentificadorUsuario();
        int GetIdUsuario();

        List<Permiso> TraerPermisos();
    }
}
