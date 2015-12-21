namespace IsIs.Models.Attacks
{
    using Contracts;

    public class Su24 : AttackBase
    {
        public override void Execute(IGroup attackerGroup, IGroup attackedGroup)
        {
            attackerGroup.Health -= attackerGroup.Health / 2;

            if (attackerGroup.CanExecuteWarEffect())
            {
                attackerGroup.ExecuteWarEffect();
                attackerGroup.Updated = true;
            }

            attackedGroup.Health -= attackerGroup.Damage * 2;
        }
    }
}