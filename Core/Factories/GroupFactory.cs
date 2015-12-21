namespace IsIs.Core.Factories
{
    using Contracts;
    using Models;

    public class GroupFactory : IGroupFactory
    {
        public IGroup Create(string groupName, int groupHealth, int groupDamage, IWarEffect warEffect, string attackName)
        {
            IGroup group = new Group(groupName, groupHealth, groupDamage, warEffect, attackName);

            return group;
        }
    }
}