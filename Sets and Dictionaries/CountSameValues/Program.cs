using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> numberOccurences = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (!numberOccurences.ContainsKey(number))
                {
                    numberOccurences.Add(number, 0);
                }
                numberOccurences[number]++;
            }

            foreach (var occurance in numberOccurences)
            {
                Console.WriteLine($"{occurance.Key} - {occurance.Value} times");
            }

        }
    }
}
