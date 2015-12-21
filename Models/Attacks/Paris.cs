namespace IsIs.Models.Attacks
{
    using Contracts;

    public class Paris : AttackBase
    {
        public override void Execute(IGroup attackerGroup, IGroup attackedGroup)
        {
            attackedGroup.Health -= attackerGroup.Damage;
        }
    }
}