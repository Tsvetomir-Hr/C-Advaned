using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private double oxygen;
        private string name;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }



        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);

                }
                oxygen = value;

                if (oxygen < 0)
                {
                    oxygen = 0;
                }
            }
        }
        private bool canBreath;

        public bool CanBreath
        {
            get { return canBreath; }
            protected set
            {
                canBreath = value;
                if (Oxygen > 0)
                {
                    canBreath = true;
                }
            }
        }


        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            Oxygen -= 10;
        }
    }
}
