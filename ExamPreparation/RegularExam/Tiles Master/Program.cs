using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainExamAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1White = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2Gray = Console.ReadLine()


                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<string, int> tilesCounter = new SortedDictionary<string, int>();
       
            Stack<int> white = new Stack<int>(input1White);

            Queue<int> gray = new Queue<int>(input2Gray);

            while (white.Any() && gray.Any())
            {
                int currentWhite = white.Pop();
                int currentGray = gray.Dequeue();
                int sum = currentWhite + currentGray;
                string currentItem = string.Empty;
                if (currentGray!=currentWhite)
                {
                    white.Push(currentWhite / 2);
                    gray.Enqueue(currentGray);
                    continue;
                }
                if (sum == 40)
                {
                    currentItem = "Sink";
                }
                else if (sum == 50)
                {
                    currentItem = "Oven";
                }
                else if (sum == 60)
                {
                    currentItem = "Countertop";
                }
                else if (sum == 70)
                {
                    currentItem = "Wall";
                }
                else
                {
                    currentItem = "Floor";
                }
                if (!tilesCounter.ContainsKey(currentItem))
                {
                    tilesCounter.Add(currentItem, 0);
                }
                tilesCounter[currentItem] += 1;
            }

            if (white.Count==0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",white)}");
            }
            if (gray.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", gray)}");
            }

            foreach (var tiles in tilesCounter.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{tiles.Key}: {tiles.Value}");
            }
        }
    }
}
