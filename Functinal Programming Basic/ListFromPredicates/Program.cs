using System;
using System.Collections.Generic;
using System.Linq;

namespace ListFromPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<int> numbers = Enumerable.Range(1, n).ToList();

            int[] divNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in divNumbers)
            {
                predicates.Add(x => x % number == 0);
            }
            foreach (int number in numbers)
            {

                bool isDiv = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDiv = false;
                        break;
                    }
                }
                if (isDiv)
                {
                Console.Write(number+ " ");

                }
            }
        }
    }
}
