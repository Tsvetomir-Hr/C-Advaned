using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] twoNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int lenghtOfFirstSet = twoNumbers[0];
            int lenghtOfSecondSet = twoNumbers[1];

            FillSet(firstSet, lenghtOfFirstSet);
            FillSet(secondSet, lenghtOfSecondSet);

            CheckSets(firstSet, secondSet);

        }

        private static void CheckSets(HashSet<int> firstSet, HashSet<int> secondSet)
        {

            firstSet.IntersectWith(secondSet);
           
            Console.WriteLine(string.Join(" ", firstSet));


        }

        private static HashSet<int> FillSet(HashSet<int> set, int length)
        {
            for (int i = 0; i < length; i++)
            {
                int n = int.Parse(Console.ReadLine());
                set.Add(n);
            }
            return set;
        }
    }
}
