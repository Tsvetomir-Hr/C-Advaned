using System;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();


            Action<int[]> addNumber = elements
               =>
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] += 1;
                }
            };
            Action<int[]> substractNumber = elements
            =>
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] -= 1;
                }
            };
            Action<int[]> multiply = elements
            =>
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] *= 2;
                }
            };

            Action<int[]> print = x 
                => Console.WriteLine(string.Join(" ",x));
            while(input!="end")
            {
                if (input=="add")
                {
                    addNumber(numbers);
                }
                if (input == "subtract")
                {
                    substractNumber(numbers);
                }
                if (input == "multiply")
                {
                    multiply(numbers);
                }
                else if (input == "print")
                {
                    print(numbers);
                }

                input = Console.ReadLine();
            }
        }
    }
}
