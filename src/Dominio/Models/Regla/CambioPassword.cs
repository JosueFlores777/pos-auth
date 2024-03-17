using Dominio.Repositories;
using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models.Regla
{
    public class CambioPassword : ICambioPassword
    {
        private readonly IUsuarioRepository usuarioRepository;

        public CambioPassword(IUsuarioRepository usuarioRepository) {
            this.usuarioRepository = usuarioRepository;
        }
        public IReglaRespuesta verificarPasswor(int idUsuario, string passwor)
        {
            var respuesta = new RegalRespuestaBasica { Cumple=true};
            var user = this.usuarioRepository.GetById(idUsuario);
            if (user is null) {
                respuesta.Cumple = false;
                return respuesta;
            }
            if (Usuario.getPassword(passwor).Equals(user.Contrasena)) respuesta.Cumple = false;
            return respuesta;
        }
    }

}
