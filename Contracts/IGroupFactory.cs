namespace IsIs.Contracts
{
    public interface IGroupFactory
    {
        IGroup Create(string groupName, int groupHealth, int groupDamage, IWarEffect warEffect, string attackName);
    }
}