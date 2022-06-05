using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] v = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            char[] c = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(char.Parse)
               .ToArray();

            Queue<char> vowels = new Queue<char>(v);
            Stack<char> consonants = new Stack<char>(c);
            List<string> wordsFound = new List<string>();
            List<string> words = new List<string>
            {
                "pear",
                "flour",
                "pork",
                "olive"
            };
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            int pearLenght = pear.Length;
            int flourLenght = flour.Length;
            int porkLenght = pork.Length;
            int oliveLenght = olive.Length;

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                vowels.Enqueue(currVowel);
                char currConsonant = consonants.Pop();

                if (pear.Contains(currVowel))
                {
                    pear = pear.Replace(currVowel, ' ');
                    pearLenght--;
                }
                if (pear.Contains(currConsonant))
                {
                    pear = pear.Replace(currConsonant, ' ');
                    pearLenght--;
                }


                if (flour.Contains(currVowel))
                {
                    flour = flour.Replace(currVowel, ' ');
                    flourLenght--;
                }
                if (flour.Contains(currConsonant))
                {
                    flour = flour.Replace(currConsonant, ' ');
                    flourLenght--;
                }


                if (pork.Contains(currVowel))
                {
                    pork = pork.Replace(currVowel, ' ');
                    porkLenght--;
                }
                if (pork.Contains(currConsonant))
                {
                    pork = pork.Replace(currConsonant, ' ');
                    porkLenght--;
                }


                if (olive.Contains(currVowel))
                {
                    olive = olive.Replace(currVowel, ' ');
                    oliveLenght--;
                }
                if (olive.Contains(currConsonant))
                {
                    olive = olive.Replace(currConsonant, ' ');
                    oliveLenght--;
                }

            }
            if (pearLenght==0)
            {
                wordsFound.Add("pear");
            }
            if (flourLenght==0)
            {
                wordsFound.Add("flour");
            }
            if (porkLenght == 0)
            {
                wordsFound.Add("pork");
            }
            if (oliveLenght == 0)
            {
                wordsFound.Add("olive");
            }


            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, wordsFound));
        }
    }
}
