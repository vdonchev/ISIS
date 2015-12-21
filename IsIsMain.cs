namespace IsIs
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Core.UI;

    public static class IsIsMain
    {
        public static void Main()
        {
            IInputReader consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter
            {
                AutoFlush = true
            };

            ICommandDispatcher commandDispatcher = new CommandDispatcher();
            IGroupFactory groupFactory = new GroupFactory();
            IWarEffectFactory warEffectFactory = new WarEffectFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IDatabase db = new EngineDb();

            var engine = new Engine(
                consoleReader,
                consoleWriter,
                commandDispatcher,
                groupFactory,
                warEffectFactory,
                attackFactory,
                db);

            engine.Start();
        }
    }
}
