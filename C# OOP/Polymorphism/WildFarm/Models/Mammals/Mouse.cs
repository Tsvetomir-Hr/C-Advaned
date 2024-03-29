﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const decimal WeightIncreaseFactor = 0.10M;
        private IList<string> AcceptedFood = new string[] { "Vegetable", "Fruit" };

        public Mouse(string name, decimal weight, string livingRegion) : base(name, weight, livingRegion)
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
            Console.WriteLine("Squeak");
        }
    }
}