namespace IsIs.Contracts
{
    public interface IWarEffectFactory
    {
        IWarEffect Create(string warEffectName);
    }
}