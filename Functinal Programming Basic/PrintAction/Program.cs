using System;

namespace FP
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Action<string[]> printNames = allNames 
                => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ",allNames));

            string[] names = Console.ReadLine().Split();

            printNames(names);
        }
    }
}
