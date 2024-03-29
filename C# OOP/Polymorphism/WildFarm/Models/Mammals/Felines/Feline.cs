﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, decimal weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; protected set; }

        public override string ToString() => $"{GetType().Name} [{Name}, {Breed}, {Weight.ToString("0.#########")}, {LivingRegion}, {FoodEaten}]";
    }
}