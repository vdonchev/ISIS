namespace IsIs.Models.WarEffects
{
    using Contracts;

    public abstract class WarEffectBase : IWarEffect
    {
        protected WarEffectBase()
        {
            this.IsExecuted = false;
        }

        public bool IsExecuted { get; set; }

        public abstract void Execute(IGroup group);

        public abstract void ConsecutiveExecution(IGroup group);
    }
}