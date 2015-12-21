namespace IsIs.Core.Commands
{
    using Contracts;

    public class ApocalypseCommand : CommandBase
    {
        public ApocalypseCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string commandType, string[] commandArgs)
        {
            this.Engine.Stop();
        }
    }
}