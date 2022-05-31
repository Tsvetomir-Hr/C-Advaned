using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car defaultCar = new Car();

           

            Console.WriteLine(defaultCar.WhoAmI());
        }
    }
}
