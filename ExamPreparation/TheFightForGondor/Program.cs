using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //plate == queue
            //waves == stack
            int numberOfWaves = int.Parse(Console.ReadLine());
            int[] plate = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(plate);

            for (int i = 1; i <= numberOfWaves; i++)
            {
                int[] waveOfOrcs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Stack<int> orcs = new Stack<int>(waveOfOrcs);
                if (i == 3)
                {
                    if (i % 3 == 0)
                    {
                        int waveToAdd = int.Parse(Console.ReadLine());
                        plates.Enqueue(waveToAdd);
                    }
                }
                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int currentPlate = plates.Dequeue();
                    int currentOrc = orcs.Pop();
                    if (currentOrc > currentPlate)
                    {
                        orcs.Push(currentOrc - currentPlate);
                    }
                    else if (currentPlate > currentOrc)
                    {
                        Queue<int> reverse = new Queue<int>(plates.Reverse());
                        reverse.Enqueue(currentPlate-currentOrc);
                        plates = new Queue<int>(reverse.Reverse());
                    }
                    if (plates.Count == 0)
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                        Environment.Exit(0);
                    }
                }
             
            }
       
            if(plates.Count>0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ",plates)}");
            }

        }
    }
}
