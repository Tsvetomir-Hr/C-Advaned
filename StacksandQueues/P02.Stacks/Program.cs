using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);


            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] tokens = command.Split();

                string action = tokens[0];
                if (action == "add")
                {
                    int n1 = int.Parse(tokens[1]);
                    int n2 = int.Parse(tokens[2]);
                    stack.Push(n1);
                    stack.Push(n2);
                }
                else if (action == "remove")
                {
                    int numbersToRemove = int.Parse(tokens[1]);

                    if (numbersToRemove <= numbers.Count())
                    {

                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");

        }

    }
}
