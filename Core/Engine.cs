namespace IsIs.Core
{
    using Contracts;
    using Exceptions;
    using Utils;

    public class Engine : IEngine
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly ICommandDispatcher commandDispatcher;

        private IGroupFactory groupFactory;
        private IWarEffectFactory warEffectFactory;
        private IAttackFactory attackFactory;

        private bool isStarted;

        public Engine(
            IInputReader reader,
            IOutputWriter writer,
            ICommandDispatcher commandDispatcher,
            IGroupFactory groupFactory,
            IWarEffectFactory warEffectFactory,
            IAttackFactory attackFactory,
            IDatabase db)
        {
            this.writer = writer;
            this.reader = reader;
            this.commandDispatcher = commandDispatcher;
            this.commandDispatcher.Engine = this;
            this.GroupFactory = groupFactory;
            this.WarEffectFactory = warEffectFactory;
            this.AttackFactory = attackFactory;
            this.Db = db;
        }

        public IOutputWriter OutputWriter
        {
            get
            {
                return this.writer;
            }
        }

        public IGroupFactory GroupFactory
        {
            get
            {
                return this.groupFactory;
            }

            private set
            {
                Validator.IfIsNull(value);
                this.groupFactory = value;
            }
        }

        public IWarEffectFactory WarEffectFactory
        {
            get
            {
                return this.warEffectFactory;
            }

            private set
            {
                Validator.IfIsNull(value);
                this.warEffectFactory = value;
            }
        }

        public IAttackFactory AttackFactory
        {
            get
            {
                return this.attackFactory;
            }

            private set
            {
                Validator.IfIsNull(value);
                this.attackFactory = value;
            }
        }

        public IDatabase Db { get; private set; }

        public void Start()
        {
            this.commandDispatcher.SeedCommands();
            this.isStarted = true;

            while (this.isStarted)
            {
                var input = this.reader.ReadNextLine();
                var inputArgs = input.Split('.');

                try
                {
                    this.commandDispatcher.DispatchCommand(inputArgs);
                }
                catch (EngineException ex)
                {
                    this.writer.Write(ex.Message);
                }
            }

            this.writer.Flush();
        }

        public void Stop()
        {
            this.isStarted = false;
        }

        public void Update()
        {
            foreach (var group in this.Db.Groups)
            {
                group.Update();
            }
        }
    }
}