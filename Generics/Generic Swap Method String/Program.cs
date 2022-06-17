using System;
using System.Linq;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string stringValue = Console.ReadLine();
                box.Items.Add(stringValue);
            }

            int[] positions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            box.Swap(positions[0],positions[1]);
            Console.WriteLine(box);
        }
    }
}
