using System;
using System.Linq;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                double a = double.Parse(Console.ReadLine());
                box.Items.Add(a);
            }

            double comparingItem = double.Parse(Console.ReadLine());
            int value = box.CountGreaterThan(comparingItem);
           
            Console.WriteLine(value);
        }
    }
}
