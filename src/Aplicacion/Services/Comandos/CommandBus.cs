using Aplicacion.CommandHandlers;
using Aplicacion.Commands;
using Aplicacion.Dtos;
using Aplicacion.Services.Validaciones;
using Aplicacion.Validators;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Aplicacion.Services.Comandos
{
    public class CommandBus : ICommandBus
    {
        private readonly IEnumerable<ICommandHandler> commandHandlers;
        private readonly IValidatorService validatorService;

        public CommandBus(IEnumerable<ICommandHandler> commandHandlers, IValidatorService validatorService)
        {
            this.commandHandlers = commandHandlers;
            this.validatorService = validatorService;
        }
        public IResponse execute(IMessage comando)
        {
            validatorService.AplicarValidador(comando);
            var instance = commandHandlers.FirstOrDefault(c => c.GetType().Name == comando.GetType().Name + "Handler");
            if (instance == null)
            {
                throw new NotImplementedException("Handler no implemntado para el mensaje: " + comando.GetType().Name);
            }
            return instance.ejecutar(comando);
        }

    }
}
