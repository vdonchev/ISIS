namespace IsIs.Core.Commands
{
    using System;
    using Contracts;

    public class CreateCommand : CommandBase
    {
        public CreateCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string commandType, string[] commandArgs)
        {
            var groupStats = commandArgs[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            var groupName = commandType;
            var health = int.Parse(groupStats[0]);
            var damage = int.Parse(groupStats[1]);
            var warEffect = this.Engine.WarEffectFactory.Create(groupStats[2]);
            var attackName = groupStats[3];

            var group = this.Engine.GroupFactory.Create(groupName, health, damage, warEffect, attackName);

            this.Engine.Db.AddGroup(group);
        }
    }
}