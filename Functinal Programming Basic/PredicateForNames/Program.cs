using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string,int,bool> isLessOrEqual = (name,length) =>
            name.Length<= length;

            string[] result = names
                .Where(x => isLessOrEqual(x, n))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,result));
                


        }
    }
}
