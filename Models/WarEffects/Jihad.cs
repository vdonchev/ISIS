namespace IsIs.Models.WarEffects
{
    using Contracts;

    public class Jihad : WarEffectBase
    {
        private const int ConsecutiveDamageLoss = 5;

        public override void Execute(IGroup group)
        {
            group.Damage *= 2;
        }

        public override void ConsecutiveExecution(IGroup group)
        {
            var newDamage = group.Damage - ConsecutiveDamageLoss;

            if (newDamage >= group.InitialDamage)
            {
                group.Damage -= ConsecutiveDamageLoss;
            }
        }
    }
}