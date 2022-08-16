using System;
using System.Collections.Generic;
using System.Linq;

namespace EncapsulationExersise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> peopleKvp = new Dictionary<string, Person>();
            Dictionary<string, Product> productsKvp = new Dictionary<string, Product>();

            string[] people = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);
                    Person person = new Person(name, money);
                    peopleKvp.Add(name, person);
                }
                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal money = decimal.Parse(products[i + 1]);
                    Product product = new Product(name, money);
                    productsKvp.Add(name, product);
                }
                string commmand = Console.ReadLine();

                while (commmand != "END")
                {

                    string[] tokens = commmand.Split();
                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person person = peopleKvp[personName];
                    Product product = productsKvp[productName];
                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                   
                    commmand = Console.ReadLine();
                }
                foreach (var (name, persons) in peopleKvp)
                {
                    string productInfo = persons.Products.Count > 0
                        ? string.Join(", ", persons.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {productInfo}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
