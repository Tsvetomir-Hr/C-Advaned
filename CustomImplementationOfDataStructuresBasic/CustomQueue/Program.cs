using System;

namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> customQueue = new Queue<int>();

            customQueue.Enqueue(10);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            Console.WriteLine(customQueue.Peek());
            customQueue.Enqueue(5);
            customQueue.Enqueue(7);
            customQueue.Enqueue(11);
            customQueue.Enqueue(17);
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Clear();
            
            Console.WriteLine(customQueue.Count);
        }
    }
}
