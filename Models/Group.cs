namespace IsIs.Models
{
    using System;
    using Contracts;
    using Core.Utils;

    public class Group : IGroup
    {
        private string name;
        private int health;
        private int damage;
        private IWarEffect warEffect;
        private string attackName;
        private int initialHealth;
        private int initialDamage;

        public Group(
            string name,
            int health,
            int damage,
            IWarEffect warEffect,
            string attackName)
        {
            this.Name = name;
            this.Health = health;
            this.InitialHealth = health;
            this.Damage = damage;
            this.WarEffect = warEffect;
            this.AttackName = attackName;
            this.Updated = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.IfStringIsNullOrEmpty(value);
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.health = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                Validator.IfIsBiggerThan(value, 0, true);
                this.damage = value;
            }
        }

        public IWarEffect WarEffect
        {
            get
            {
                return this.warEffect;
            }

            private set
            {
                Validator.IfIsNull(value);
                this.warEffect = value;
            }
        }

        public string AttackName
        {
            get
            {
                return this.attackName;
            }

            set
            {
                Validator.IfStringIsNullOrEmpty(value);
                this.attackName = value;
            }
        }

        public bool Updated { get; set; }

        public int InitialHealth
        {
            get
            {
                return this.initialHealth;
            }

            set
            {
                this.initialHealth = value;
            }
        }

        public int InitialDamage
        {
            get
            {
                return this.initialDamage;
            }

            set
            {
                this.initialDamage = value;
            }
        }

        public bool CanExecuteWarEffect()
        {
            var canExecute = this.Health <= this.InitialHealth / 2 && this.WarEffect.IsExecuted == false;

            return canExecute;
        }

        public void ExecuteWarEffect()
        {
            if (!this.CanExecuteWarEffect())
            {
                throw new InvalidOperationException(
                    "Effect is already executed OR does not meet the requrements for executing");
            }

            this.InitialHealth = this.Health;
            this.InitialDamage = this.Damage;

            this.WarEffect.Execute(this);
            this.WarEffect.IsExecuted = true;
        }

        public void Update()
        {
            if (this.Updated)
            {
                this.Updated = false;
            }
            else
            {
                if (this.CanExecuteWarEffect())
                {
                    this.ExecuteWarEffect();
                }
                else
                {
                    if (this.WarEffect.IsExecuted)
                    {
                        this.WarEffect.ConsecutiveExecution(this);
                    }
                }
            }

            this.Updated = false;
        }

        public override string ToString()
        {
            var isAlive = this.Health > 0;

            string result = $"Group {this.Name}";
            if (isAlive)
            {
                result += $": {this.Health} HP, {this.Damage} Damage";
            }
            else
            {
                result += " AMEN";
            }

            return result;
        }
    }
}