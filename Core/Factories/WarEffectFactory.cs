namespace IsIs.Core.Factories
{
    using System;
    using Contracts;
    using Models.WarEffects;

    public class WarEffectFactory : IWarEffectFactory
    {
        public IWarEffect Create(string warEffectName)
        {
            switch (warEffectName)
            {
                case "Jihad":
                    return new Jihad();
                case "Kamikaze":
                    return new Kamikaze();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}