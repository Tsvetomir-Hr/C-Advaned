using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get { return power; }
            private set 
            { 
                power = value;
                if (power<0)
                {
                    Power = 0;
                }
            }
        }



        public bool IsFinished()
        {
            if (Power==0)
            {
                return true;
            }
            return false;
        }

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
