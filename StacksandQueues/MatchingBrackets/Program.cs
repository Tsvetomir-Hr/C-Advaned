using System;
using System.Collections.Generic;
using System.Linq;

namespace p01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            string inBrackets = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {


                    inBrackets = input.Substring(stack.Peek(), i - stack.Pop() + 1);
                    Console.WriteLine(inBrackets);
                }
            }


        }
    }
}
