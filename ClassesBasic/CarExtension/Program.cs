using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            

            Car car = new Car();
            car.Make = "Audi";
            car.Model = "A5";
            car.Year = 1995;
            car.FuelQuantity = 150;
            car.FuelConsumption = 2;


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Driving 50:");
                car.Drive(40);

                Console.WriteLine(car.WhoAmI());
            }

        }
    }
}
