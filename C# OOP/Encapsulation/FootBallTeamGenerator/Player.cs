using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallTeamGenerator
{
    public class Player
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
  
        private string name;
        private int stats;

        public Player(string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting)
        {
            Name = name;

            ValidateStat("Endurance",endurance);
            ValidateStat("Sprint", sprint);
            ValidateStat("Dribble", dribble);
            ValidateStat("Passing", passing);
            ValidateStat("Shooting", shooting);

            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
         
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public double Stats
   => (endurance + sprint + dribble + passing + shooting) / 5.0;

        private void ValidateStat(string name,int stat)
        {
            if (stat < 1 || stat > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }

    }
}
