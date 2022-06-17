using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input1 = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int valueOfATaskToKill = int.Parse(Console.ReadLine());
            Queue<int> treads = new Queue<int>(input2);
            Stack<int> tasks = new Stack<int>(input1);

            while (tasks.Contains(valueOfATaskToKill))
            {

                int currentTread = treads.Peek();
                int currnetTask = tasks.Peek();

                if (currnetTask == valueOfATaskToKill)
                {
                    Console.WriteLine($"Thread with value {currentTread} killed task {valueOfATaskToKill}");
                    break;
                }
                if (currentTread<currnetTask)
                {
                    treads.Dequeue();
                }
                else // currentTread>=CurrentTask we remove both values.
                {
                 
                    treads.Dequeue();
                    tasks.Pop();
                }
                
            }
            Console.WriteLine(string.Join(" ",treads));
        }
    }
}
