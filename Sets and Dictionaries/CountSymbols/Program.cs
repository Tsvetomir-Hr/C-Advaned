using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Dictionary<char,int> symbolCounts = new Dictionary<char,int>();

            string text= Console.ReadLine();

            foreach (char c in text)
            {
                if (!symbolCounts.ContainsKey(c))
                {
                    symbolCounts.Add(c, 0);
                }
                symbolCounts[c]++;
            }

            foreach (var kvp in symbolCounts.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
