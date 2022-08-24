using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double BaseHealth { get; private set; }

        public double Health
        {
            get { return health; }
            set
            {
                health = value;
                if (health < 0)
                {
                    health = 0;
                    IsAlive = false;
                }
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
        }
        public double BaseArmor { get; private set; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                armor = value;

                if (armor < 0)
                {
                    armor = 0;
                }
            }
        }
        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                return;
            }
            double leftPoints = hitPoints - Armor > 0
                ? hitPoints - Armor
                : 0;
            Armor -= hitPoints;
            Health -= leftPoints;

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            item.AffectCharacter(this);
        }


        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}