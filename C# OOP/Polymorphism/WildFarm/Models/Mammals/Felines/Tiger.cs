﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Tiger : Feline
    {
        private const decimal WeightIncreaseFactor = 1.00M;
        private IList<string> AcceptedFood = new string[] { "Meat" };

        public Tiger(string name, decimal weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(string foodType, int quantity)
        {
            if (!AcceptedFood.Contains(foodType))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
            }

            Weight += quantity * WeightIncreaseFactor;
            FoodEaten += quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}