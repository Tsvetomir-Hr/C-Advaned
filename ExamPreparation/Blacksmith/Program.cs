using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] s = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] c = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            Queue<int> steel = new Queue<int>(s);
            Stack<int> carbon = new Stack<int>(c);

            Dictionary<string, int> swords = new Dictionary<string, int>();

            int forgedSwords = 0;
            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Peek();
                int currentCarbon = carbon.Peek();
                string sword = string.Empty;
                if (currentSteel + currentCarbon == 70)
                {
                    sword = "Gladius";
                    steel.Dequeue();
                    carbon.Pop();

                    if (!swords.ContainsKey(sword))
                    {
                        swords.Add(sword, 0);
                        
                    }
                    swords[sword] += 1;
                    forgedSwords++;
                }
                else if (currentSteel + currentCarbon == 80)
                {
                    sword = "Shamshir";
                    steel.Dequeue();
                    carbon.Pop();

                    if (!swords.ContainsKey(sword))
                    {
                        swords.Add(sword, 0);
                    }
                    swords[sword] += 1;
                    forgedSwords++;
                }
                else if (currentSteel + currentCarbon == 90)
                {
                    sword = "Katana";
                    steel.Dequeue();
                    carbon.Pop();

                    if (!swords.ContainsKey(sword))
                    {
                        swords.Add(sword, 0);
                    }
                    swords[sword] += 1;
                    forgedSwords++;
                }
                else if (currentSteel + currentCarbon == 110)
                {
                    sword = "Sabre";
                    steel.Dequeue();
                    carbon.Pop();

                    if (!swords.ContainsKey(sword))
                    {
                        swords.Add(sword, 0);
                    }
                    swords[sword] += 1;
                    forgedSwords++;
                }
                else if (currentSteel + currentCarbon == 150)
                {
                    sword = "Broadsword";
                    steel.Dequeue();
                    carbon.Pop();

                    if (!swords.ContainsKey(sword))
                    {
                        swords.Add(sword, 0);
                    }
                    swords[sword] += 1;
                    forgedSwords++;
                }


                if (sword == string.Empty)
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop() + 5);

                }
            }
            if (swords.Count > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            if (swords.Count > 0)
            {
                foreach (var sword in swords.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
