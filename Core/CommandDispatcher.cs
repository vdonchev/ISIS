namespace IsIs.Core
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using Contracts;
    using Exceptions;

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDictionary<string, ICommand> commandsByName;

        public CommandDispatcher()
        {
            this.commandsByName = new Dictionary<string, ICommand>();
        }

        public IEngine Engine { get; set; }

        public void DispatchCommand(string[] commandArgs)
        {
            var commandType = commandArgs[0];

            for (var i = 1; i < commandArgs.Length; i++)
            {
                var commandSplittedArgs = commandArgs[i].Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                var commandName = commandSplittedArgs[0];

                if (!this.commandsByName.ContainsKey(commandName))
                {
                    throw new EngineException(
                        "Command is not supported by engine");
                }

                var command = this.commandsByName[commandName];

                try
                {
                    command.Execute(commandType, commandSplittedArgs);
                }
                catch (EngineException ex)
                {
                    this.Engine.OutputWriter.Write(ex.Message);
                }

                this.Engine.Update();
            }
        }

        public void SeedCommands()
        {
            this.commandsByName["create"] = new CreateCommand(this.Engine);
            this.commandsByName["attack"] = new AttackCommand(this.Engine);
            this.commandsByName["status"] = new StatusCommand(this.Engine);
            this.commandsByName["akbar"] = new AkbarCommand(this.Engine);
            this.commandsByName["apocalypse"] = new ApocalypseCommand(this.Engine);
        }
    }
}