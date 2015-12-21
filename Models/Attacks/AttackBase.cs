namespace IsIs.Models.Attacks
{
    using Contracts;

    public abstract class AttackBase : IAttack
    {
        public abstract void Execute(IGroup attackerGroup, IGroup attackedGroup);
    }
}