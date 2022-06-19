using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> elements = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake lake = new Lake(elements);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
