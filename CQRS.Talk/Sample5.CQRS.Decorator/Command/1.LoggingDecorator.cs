﻿using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using Newtonsoft.Json;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class LoggingDecorator<TCommand> : 
        ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public LoggingDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }


        public void Handle(TCommand command)
        {
            var serialisedData = JsonConvert.SerializeObject(command);
            var commandName = command.GetType().Name;

            Logger.Info("LOG: Start handler {0} with data {1}", commandName, serialisedData);

            decorated.Handle(command);

            Logger.Info("LOG: Finished with command {0}", commandName);
        }
    }
}
