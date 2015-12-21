namespace IsIs.Contracts
{
    public interface IWarEffect
    {
        bool IsExecuted { get; set; }

        void Execute(IGroup group);

        void ConsecutiveExecution(IGroup group);
    }
}