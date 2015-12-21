namespace IsIs.Contracts
{
    public interface IAttackFactory
    {
        IAttack Create(string attackName);
    }
}