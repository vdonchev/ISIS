namespace IsIs.Contracts
{
    public interface IEngine : IUpdatable
    {
        IOutputWriter OutputWriter { get; }

        IGroupFactory GroupFactory { get; }

        IWarEffectFactory WarEffectFactory { get; }

        IAttackFactory AttackFactory { get; }

        IDatabase Db { get; }

        void Start();

        void Stop();
    }
}