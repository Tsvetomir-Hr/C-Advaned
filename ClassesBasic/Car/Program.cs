using System;

namespace P01.Car
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Car bmw = new Car()
            {

                Name = "3",
                Company = "BMW",
                Category = "Cars",
                Price = 3000

            };

            bmw.Drive(23);
            bmw.Drive(33);

            Car audi = new Car()
            {
                Name = "a3",
                Company = "Audi",
                Category = "Category",
                Price = 5000
            };

            audi.Drive(45);
            audi.Drive(55);



        }


    }
}
