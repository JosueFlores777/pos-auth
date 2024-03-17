using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Dtos.Usuario;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Repositories;
using Dominio.Repositories.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    class ConsultarUsuariosHandler : AbstractHandler<ConsultarUsuarios>
    {
        private readonly IUsuarioRepository usuariosRepository;
        private readonly IMapper mapper;

        public ConsultarUsuariosHandler(IUsuarioRepository usuariosRepository, IMapper mapper)
        {
            this.usuariosRepository = usuariosRepository;
            this.mapper = mapper;
        }
        public override IResponse Handle(ConsultarUsuarios message)
        {
            IPagina<Dominio.Models.Usuario> respuesta; 
            if (!string.IsNullOrWhiteSpace(message.Nombre) || !string.IsNullOrWhiteSpace(message.correo)  ||  message.idDepartamento != 0){ 
                respuesta = usuariosRepository.ConsultarPaginadoConRol(message, new BuscarUsuarioPorNombreYCorreo(message.Nombre, message.correo,message.idDepartamento)); }
            else
            {
                respuesta = usuariosRepository.ConsultarPaginadoConRol(message);
            }
       
            return mapper.Map<DtoUsuariosPaginados>(respuesta); 

        }
    }
}