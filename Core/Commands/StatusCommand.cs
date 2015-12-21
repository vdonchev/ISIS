namespace IsIs.Core.Commands
{
    using System.Linq;
    using Contracts;

    public class StatusCommand : CommandBase
    {
        public StatusCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string commandType, string[] commandArgs)
        {
            var sortedGroups = this.Engine.Db.Groups
                .OrderByDescending(g => g.Health)
                .ThenByDescending(g => g.Damage);

            foreach (var group in sortedGroups)
            {
                this.Engine.OutputWriter.Write(group.ToString());
            }
        }
    }
}