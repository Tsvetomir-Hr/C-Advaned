using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, decimal>> supermarkets =
                new Dictionary<string, Dictionary<string, decimal>>();

            while (input[0]!="Revision")
            {
                string shop = input[0];
                string productName = input[1];
                decimal productPrice  = decimal.Parse(input[2]);

                if (!supermarkets.ContainsKey(shop))
                {
                    supermarkets.Add(shop, new Dictionary<string, decimal>());

                }
                supermarkets[shop].Add(productName, productPrice);

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach(var shop in supermarkets.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value.ToString("0.##########")}");
                }
            }
        }
    }
}
