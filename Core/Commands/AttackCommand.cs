namespace IsIs.Core.Commands
{
    using System;
    using Contracts;

    public class AttackCommand : CommandBase
    {
        public AttackCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string commandType, string[] commandArgs)
        {
            var attackerName = commandType;
            var attackedName = commandArgs[1];

            var attackerGroup = this.Engine.Db.GetGroupByName(attackerName);
            var attackedGroup = this.Engine.Db.GetGroupByName(attackedName);

            if (attackedGroup.Health == 0)
            {
                throw new InvalidOperationException("Attacker group is dead.");
            }

            if (attackedGroup.Health == 0)
            {
                throw new InvalidOperationException("Attacked group is dead.");
            }

            var attack = this.Engine.AttackFactory.Create(attackerGroup.AttackName);

            attack.Execute(attackerGroup, attackedGroup);
        }
    }
}