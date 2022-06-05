using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Dipping sauce   150
            //  Green salad     250
            //  Chocolate cake  300
            //  Lobster         400

            Dictionary<string, int> cookedDishes = new Dictionary<string, int>();

            int[] ing = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] fresh = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(ing);
            Stack<int> freshness = new Stack<int>(fresh);

            while (freshness.Count > 0 && ingredients.Count > 0)
            {
                int currentIngredient = ingredients.Peek();
                if (currentIngredient==0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int currentFreshness = freshness.Pop();

                string dish = string.Empty;
                if (currentFreshness * currentIngredient == 150)
                {
                    dish = "Dipping sauce";
                    if (!cookedDishes.ContainsKey(dish))
                    {
                        cookedDishes.Add(dish, 0);
                    }
                    cookedDishes[dish] += 1;
                    ingredients.Dequeue();
                }
                else if (currentFreshness * currentIngredient == 250)
                {
                    dish = "Green salad";
                    if (!cookedDishes.ContainsKey(dish))
                    {
                        cookedDishes.Add(dish, 0);
                    }
                    cookedDishes[dish] += 1;
                    ingredients.Dequeue();
                }
                else if (currentFreshness * currentIngredient == 300)
                {
                    dish = "Chocolate cake";
                    if (!cookedDishes.ContainsKey(dish))
                    {
                        cookedDishes.Add(dish, 0);
                    }
                    cookedDishes[dish] += 1;
                    ingredients.Dequeue();
                }
                else if (currentFreshness * currentIngredient == 400)
                {
                    dish = "Lobster";
                    if (!cookedDishes.ContainsKey(dish))
                    {
                        cookedDishes.Add(dish, 0);
                    }
                    cookedDishes[dish] += 1;
                    ingredients.Dequeue();
                }
                else
                {
                 
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            if (cookedDishes.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in cookedDishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
