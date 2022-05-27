using System;
using System.Collections.Generic;

namespace P05.CitiesBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> keyValuePairs = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!keyValuePairs.ContainsKey(continent))
                {
                    keyValuePairs.Add(continent, new Dictionary<string, List<string>>());

                }
                if (!keyValuePairs[continent].ContainsKey(country))
                {
                    keyValuePairs[continent][country] = new List<string>();
                }

                keyValuePairs[continent][country].Add(city);

            }

            foreach(var continent in keyValuePairs)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach(var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }

        }
    }
}
