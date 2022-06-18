using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rosesinput1 = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] liliesinput2 = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(liliesinput2);
            Queue<int> roses = new Queue<int>(rosesinput1);
            double wreathsCounter = 0;

            double storedSums = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Peek() + roses.Peek();

                if (sum ==15)
                {
                    wreathsCounter++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum >15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else //sum < 15
                {
                    storedSums+=sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
                
            }

            wreathsCounter += Math.Floor(storedSums / 15);
            if (wreathsCounter<5)
            {
                Console.WriteLine($"You didn't make it, you need {5-wreathsCounter} wreaths more!");
            }
            else
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter} wreaths!");
            }


        }
    }
}
