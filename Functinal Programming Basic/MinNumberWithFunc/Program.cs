using System;
using System.Linq;

namespace MinNumberWithFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int> smallest = nums
                 =>
             {
                 int minValue = int.MaxValue;

                 foreach (int number in nums)
                 {
                     if (number < minValue)
                     {
                         minValue = number;
                     }
                 }
                 return minValue;
             };
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(smallest(numbers));
        }
    }
}
