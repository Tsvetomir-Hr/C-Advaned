using System;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaName = Console.ReadLine().Split();
            string name = pizzaName[1];
            string[] doughInput = Console.ReadLine().Split();

            string flourType = doughInput[1];
            string bakingTechnique = doughInput[2];
            int grams = int.Parse(doughInput[3]);


            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, grams);

                Pizza pizza = new Pizza(name, dough);
                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppingInput = input.Split();
                    string toppingType = toppingInput[1];
                    int weight = int.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, weight);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

          

        }
    }
}
