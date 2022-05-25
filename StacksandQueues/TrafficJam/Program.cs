using System;
using System.Collections.Generic;
using System.Linq;

namespace p01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numberOfCars = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            string input = Console.ReadLine();

            int passedCars = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    if (queue.Count == 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    for (int i = 0; i < numberOfCars; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        passedCars++;
                        if (queue.Count == 0)
                        {
                            break;
                        }
                    }
                    input = Console.ReadLine();
                    continue;
                }

                queue.Enqueue(input);

                input = Console.ReadLine();

            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");





        }
    }
}
