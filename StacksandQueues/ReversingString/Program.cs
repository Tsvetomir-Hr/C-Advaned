using System;
using System.Collections.Generic;

namespace p01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                stack.Push(ch);

            }


            foreach (char ch in stack)
            {
                Console.Write(ch);
            }
        }
    }
}
