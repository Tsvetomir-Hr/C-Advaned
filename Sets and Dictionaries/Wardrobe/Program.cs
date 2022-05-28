using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] items = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < items.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(items[j]))
                    {
                        wardrobe[color].Add(items[j],0);
                    }
                    wardrobe[color][items[j]]++;

                }
             
            }

           
            string[] clothWeAreLoookingFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string colour = clothWeAreLoookingFor[0];
            string typeOfCloth = clothWeAreLoookingFor[1];



            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var cloth in kvp.Value)
                {
                    if (kvp.Key == colour && cloth.Key == typeOfCloth)
                    {

                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");

                    }
                }
            }

        }
    }
}
