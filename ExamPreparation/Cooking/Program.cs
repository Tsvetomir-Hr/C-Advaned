using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputQueue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputStack = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(inputQueue);
            Stack<int> ingredients = new Stack<int>(inputStack);
            SortedDictionary<string, int> cookedFood = new SortedDictionary<string, int>();
            cookedFood.Add("Bread", 0);
            cookedFood.Add("Cake", 0);
            cookedFood.Add("Pastry", 0);
            cookedFood.Add("Fruit Pie", 0);
           
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentingredient = ingredients.Peek();
                int sum = currentLiquid + currentingredient;
                string currentFood = string.Empty;

                if (sum == 25)
                {
                    currentFood = "Bread";

                }
                else if (sum == 50)
                {
                    currentFood = "Cake";
                }
                else if (sum == 75)
                {
                    currentFood = "Pastry";
                }
                else if (sum == 100)
                {
                    currentFood = "Fruit Pie";
                }
                if (currentFood != string.Empty)
                {
                    ingredients.Pop();
                    if (!cookedFood.ContainsKey(currentFood))
                    {
                        cookedFood.Add(currentFood, 0);
                    }
                    cookedFood[currentFood] += 1;
                }
                else
                {
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (cookedFood.Values.All(x => x > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            

            foreach (var food in cookedFood)
            {

                Console.WriteLine($"{food.Key}: {food.Value}");

            }







        }
    }
}
