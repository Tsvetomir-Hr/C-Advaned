using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<decimal> numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(n=>n+n*0.2m)
                .ToList();

            numbers.ForEach(n=>Console.WriteLine($"{n:F2}"));

            

        }
    }
}
