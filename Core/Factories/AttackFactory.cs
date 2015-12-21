namespace IsIs.Core.Factories
{
    using System;
    using Contracts;
    using Models.Attacks;

    public class AttackFactory : IAttackFactory
    {
        public IAttack Create(string attackName)
        {
            switch (attackName)
            {
                case "Paris":
                    return new Paris();
                case "SU24":
                    return new Su24();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}