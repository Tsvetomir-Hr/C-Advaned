using System;
using System.Collections.Generic;
using System.Linq;

namespace p01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string customer = Console.ReadLine();

            Queue<string> queue = new Queue<string>();
            while (customer != "End")
            {
                if (customer == "Paid")
                {
                    foreach (var client in queue)
                    {
                        Console.WriteLine(client);
                    }
                    queue.Clear();
                    customer = Console.ReadLine();
                    continue;
                }
                queue.Enqueue(customer);

                customer = Console.ReadLine();

            }


            Console.WriteLine($"{queue.Count} people remaining.");

        }
    }
}
