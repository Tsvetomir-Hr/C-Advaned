using System;
using System.Collections.Generic;

namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
           Dictionary<int, int> allNumbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());


                if (!allNumbers.ContainsKey(number))
                {
                    allNumbers.Add(number, 0);
                }
                allNumbers[number] += 1;

            }

            foreach (var number in allNumbers)
            {
                if (number.Value%2==0)
                {
                    Console.WriteLine(number.Key);
                    break;
                }
            }

         
        }
    }
}
