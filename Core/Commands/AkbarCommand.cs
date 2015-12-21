namespace IsIs.Core.Commands
{
    using Contracts;

    public class AkbarCommand : CommandBase
    {
        public AkbarCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string commandType, string[] commandArgs)
        {
            // simply do nothing
        }
    }
}