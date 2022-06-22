using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] inputEffect = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] inputCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffect = new Queue<int>(inputEffect);

            Stack<int> bombCasing = new Stack<int>(inputCasing);

            Dictionary<string,int> bombPouch = new Dictionary<string,int>();
            bombPouch.Add("Cherry Bombs", 0);
            bombPouch.Add("Datura Bombs", 0);
            bombPouch.Add("Smoke Decoy Bombs", 0);
            bool isThereEnoughtBombs = false;
            while (bombEffect.Count > 0 && bombCasing.Count > 0)
            {
                if (bombPouch.Values.All(x=>x>=3))
                {
                    isThereEnoughtBombs = true;
                    break;
                }
                int currentEffect = bombEffect.Peek();
                int currentCasing = bombCasing.Pop();
                int sum = currentEffect + currentCasing;
                string typeBomb = string.Empty;
                if (sum==40)
                {
                    typeBomb = "Datura Bombs";
                    bombEffect.Dequeue();
                }
                else if (sum == 60)
                {
                    typeBomb = "Cherry Bombs";
                    bombEffect.Dequeue();
                }
                else if (sum == 120)
                {
                    typeBomb = "Smoke Decoy Bombs";
                    bombEffect.Dequeue();
                }
                else
                {
                    bombCasing.Push(currentCasing - 5);
                }
                if (typeBomb!=string.Empty)
                {
                    if (!bombPouch.ContainsKey(typeBomb))
                    {
                        bombPouch.Add(typeBomb, 0);
                    }
                    bombPouch[typeBomb] += 1;
                }
            }
            if (isThereEnoughtBombs)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffect.Count>0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            foreach (var bomb in bombPouch.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
