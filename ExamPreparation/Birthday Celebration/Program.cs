using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] capacity = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] gramsOfPlates = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Stack<int> plates = new Stack<int>(gramsOfPlates);

            Queue<int> guests = new Queue<int>(capacity);
            int wastedGramsFood = 0;
            while (true)
            {
                if (plates.Count==0)
                {
                    Console.WriteLine($"Guests: {string.Join(" ",guests)}");
                    break;
                }
                if (guests.Count==0)
                {
                    Console.WriteLine($"Plates: {string.Join(" ",plates)}");
                    break;
                }
                int currentGuest = guests.Peek();
                int currentPlateFood = plates.Peek();
                int result = 0;
                if (currentGuest-currentPlateFood<=0)
                {
                    result = Math.Abs(currentGuest - currentPlateFood);
                    wastedGramsFood += result;
                    guests.Dequeue();
                    plates.Pop();
                }
                else
                {//11-9 
                    guests.Dequeue();
                    plates.Pop();
                    result=currentGuest- currentPlateFood;
                    guests = new Queue<int>(guests.Reverse());
                    guests.Enqueue(result);
                    guests = new Queue<int>(guests.Reverse());
                }

            }
            Console.WriteLine($"Wasted grams of food: {wastedGramsFood}");
        }
    }
}
