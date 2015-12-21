namespace IsIs.Contracts
{
    public interface ICommandDispatcher
    {
        IEngine Engine { get; set; }

        void DispatchCommand(string[] commandArgs);

        void SeedCommands();
    }
}