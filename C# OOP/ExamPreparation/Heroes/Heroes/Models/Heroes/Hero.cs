using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private IWeapon weapon;
        private int armour;
      

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }



        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                health = value;
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }

        }

        public bool IsAlive => this.Health > 0;
        
        
        public void AddWeapon(IWeapon weapon)
        {
            if (this.Weapon != null)
            {
                return;
            }
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            var leftArmor = this.Armour - points;
            if (leftArmor<0)
            {
                this.Armour = 0;


                var leftHealth = this.Health + leftArmor;
                if (leftHealth<0)
                {
                    this.Health = 0;

                }
                else
                {
                    this.Health = leftHealth;
                }
            }
            else
            {
                this.Armour = leftArmor;
            }

        }
    }
}
