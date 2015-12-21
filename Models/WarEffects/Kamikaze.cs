namespace IsIs.Models.WarEffects
{
    using Contracts;

    public class Kamikaze : WarEffectBase
    {
        private const int ConsecutiveHealthLoss = 10;
        private const int HealthBonus = 50;

        public override void Execute(IGroup group)
        {
            group.Health += HealthBonus;
        }

        public override void ConsecutiveExecution(IGroup group)
        {
            group.Health -= ConsecutiveHealthLoss;
        }
    }
}