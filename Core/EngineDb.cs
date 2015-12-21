namespace IsIs.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class EngineDb : IDatabase
    {
        private ICollection<IGroup> groups = new List<IGroup>();

        public IEnumerable<IGroup> Groups
        {
            get
            {
                return this.groups;
            }
        }

        public void AddGroup(IGroup @group)
        {
            this.groups.Add(group);
        }

        public IGroup GetGroupByName(string groupName)
        {
            var group = this.Groups
                .FirstOrDefault(g => g.Name == groupName);

            return group;
        }
    }
}