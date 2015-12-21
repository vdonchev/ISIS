namespace IsIs.Contracts
{
    public interface IGroup : IUpdatable
    {
        string Name { get; }

        int Health { get; set; }

        int Damage { get; set; }

        int InitialDamage { get; set; }

        int InitialHealth { get; set; }

        IWarEffect WarEffect { get; }

        string AttackName { get; }

        bool Updated { get; set; }

        void ExecuteWarEffect();

        bool CanExecuteWarEffect();
    }
}