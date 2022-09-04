using System;

namespace CustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {


            Stack<int> customStack = new Stack<int>();
             
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);
            customStack.Pop();
            customStack.Push(10);
           
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
