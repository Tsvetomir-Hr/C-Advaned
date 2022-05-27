using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int [] sorted = numbers.OrderByDescending(x => x).ToArray();


            if (sorted.Length<=3)
            {
                foreach (var number in sorted)
                {
                    Console.Write($"{number} ");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
        }
    }
}
