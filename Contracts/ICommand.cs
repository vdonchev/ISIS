namespace IsIs.Contracts
{
    public interface ICommand
    {
        IEngine Engine { get; }

        void Execute(string commandType, string[] commandArgs);
    }
}