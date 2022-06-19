using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputMeals = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int mealCounter = 0;
            Queue<string> meals = new Queue<string>(inputMeals);
            Stack<int> calories = new Stack<int>(numbers);

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currentMeal = meals.Dequeue();
                int currentCalories = calories.Pop();

                if (currentMeal == "salad")
                {
                    currentCalories -= 350;
                }
                else if (currentMeal == "soup")
                {
                    currentCalories -= 490;
                }
                else if (currentMeal == "pasta")
                {
                    currentCalories -= 680;
                }
                else
                {
                    currentCalories -= 790;
                }
                mealCounter++;

                if (currentCalories < 0)
                {
                    if (calories.Count==0)
                    {
                        break;
                    }
                    calories.Push(calories.Pop() - Math.Abs(currentCalories));
                }
             
                else
                {
                    calories.Push(Math.Abs(currentCalories));
                }
            }
            if (meals.Count==0)
            {
                Console.WriteLine($"John had {mealCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ",calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",meals)}");
            }

        }
    }
}
