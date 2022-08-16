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
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Health = BaseHealth;
            Armor = BaseArmor;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
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
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
                if (health <= 0)
                {
                    health = 0;
                    IsAlive = false;
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
                if (armor <= 0)
                {
                    armor = 0;
                }
            }
        }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public bool IsAlive { get; private set; } = true;

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            //Example: Health: 100, Armor: 30, Hit Points: 50  Health: 90, Armor: 0

            double restArmor = this.Armor - hitPoints;
            if (restArmor<0) //-20
            {
                Armor = 0;
                double restHealth = Health + restArmor; //80 health
                if (restHealth<=0)
                {
                    Health = 0;
                    IsAlive=false;
                }
                else
                {
                    Health += restArmor; //80
                }
            }
            else
            {
                armor -= hitPoints;
            }
         
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
            
            
        }

    }
}