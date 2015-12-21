namespace IsIs.Contracts
{
    public interface IAttack
    {
        void Execute(IGroup attackerGroup, IGroup attackedGroup);
    }
}