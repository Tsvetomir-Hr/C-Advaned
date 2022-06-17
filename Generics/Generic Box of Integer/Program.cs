using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                box.Items.Add(number);
            }

            Console.WriteLine(box);
        }
    }
}
