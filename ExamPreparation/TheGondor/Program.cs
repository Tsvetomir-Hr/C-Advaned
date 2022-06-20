using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] inputPlates = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            Queue<int> plates = new Queue<int>(inputPlates);
            for (int i = 1; i <= n; i++)
            {
                int[] inputOrcs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Stack<int> orcs = new Stack<int>(inputOrcs);
                if (i % 3 == 0 && i != 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int currentPlate = plates.Peek();
                    int currnetOrc = orcs.Peek();
                    if (currnetOrc > currentPlate)
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (currentPlate > currnetOrc)
                    {
                        orcs.Pop();
                        plates.Dequeue();
                        Queue<int> reversed = new Queue<int>(plates.Reverse());
                        reversed.Enqueue(currentPlate - currnetOrc);
                        plates = new Queue<int>(reversed.Reverse());
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }
                if (plates.Count == 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                    Environment.Exit(0);
                }

            }
            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");




        }
    }
}
