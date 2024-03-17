using Aplicacion.Commands.Usuario;
using Aplicacion.Dtos;
using Aplicacion.Helpers;
using AutoMapper;
using Dominio.Especificaciones;
using Dominio.Helpers;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.CommandHandlers.Usuario
{
    public class CodigoTemporalHandler : AbstractHandler<CodigoTemporal>
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICorreoHelper correoHelper;
        private readonly IImportadorRepository importadorRepository;
        public CodigoTemporalHandler(IMapper mapper, ICorreoHelper correoHelper, IImportadorRepository importadorRepository, IUsuarioRepository usuarioRepository)
        {
            this.mapper = mapper;
            this.usuarioRepository = usuarioRepository;
            this.correoHelper = correoHelper;
            this.importadorRepository = importadorRepository;
        }
        public override IResponse Handle(CodigoTemporal message)
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; 
            var random = new Random(); 
            var result = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

            var resp = result;
            var solicitud = usuarioRepository.GetAll().FirstOrDefault(x=>x.IdentificadorAcceso == message.IdentificadorAcceso);
            if (solicitud != null)
            {
                solicitud.CodigoTemporal = resp;
                usuarioRepository.Update(solicitud.Id, solicitud);
                var motivo = "Codigo de Verificación: ".ToString();
                var lista = new List<string>();
                if (solicitud.TipoUsuario == "importador")
                {
                    var importador = importadorRepository.Filter(new BuscarImportadorPorIdentificador (message.IdentificadorAcceso)).FirstOrDefault();
                    if (solicitud != null) lista.Add(importador.Correo);
                }
                else {
                    if (solicitud != null) lista.Add(solicitud.IdentificadorAcceso);
                }
                

                correoHelper.EnviarCorreoModificarSolicitud(lista, motivo, resp);
            }
           
            return new OkResponse();
        }
    }
}
