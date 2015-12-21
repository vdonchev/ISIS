namespace IsIs.Contracts
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        IEnumerable<IGroup> Groups { get; }

        void AddGroup(IGroup group);

        IGroup GetGroupByName(string groupName);
    }
}