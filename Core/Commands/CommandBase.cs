namespace IsIs.Core.Commands
{
    using Contracts;

    public abstract class CommandBase : ICommand
    {
        protected CommandBase(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine { get; private set; }

        public abstract void Execute(string commandType, string[] commandArgs);
    }
}