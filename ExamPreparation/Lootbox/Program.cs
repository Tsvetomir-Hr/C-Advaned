using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1box = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2box = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> claimedItems = new List<int>();

            Queue<int> FirstBox = new Queue<int>(input1box);
            Stack<int> SecondBox = new Stack<int>(input2box);
            while (true)
            {
                int sum = 0;
                if (FirstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (SecondBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
                int currentFirstBoxItem = FirstBox.Peek();
                int currentSecondBoxItem = SecondBox.Peek();
                sum = currentFirstBoxItem + currentSecondBoxItem;
                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    FirstBox.Dequeue();
                    SecondBox.Pop();
                }
                else
                {
                    FirstBox.Enqueue(SecondBox.Pop());
                }
            }
            if (claimedItems.Sum()>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
