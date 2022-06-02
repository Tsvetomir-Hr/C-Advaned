using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        public Tires(double presure, int age)
        {
            Presure = presure;
            Age = age;
        }

        public double Presure { get; set; }
        public int Age { get; set; }
    }
}
