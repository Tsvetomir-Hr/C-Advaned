using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                double tire1 = double.Parse(input[5]);
                int tireAge1 = int.Parse(input[6]);

                double tire2 = double.Parse(input[7]);
                int tireAge2 = int.Parse(input[8]);

                double tire3 = double.Parse(input[9]);
                int tireAge3 = int.Parse(input[10]);

                double tire4 = double.Parse(input[11]);
                int tireAge4 = int.Parse(input[12]);

                Engine engine = new Engine(enginePower, engineSpeed);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tires[] tires = new Tires[]
                {
                    new Tires(tire1,tireAge1),
                    new Tires(tire2,tireAge2),
                    new Tires(tire3,tireAge3),
                    new Tires(tire4,tireAge4),
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> carsToPrint = new List<Car>();
            if (command == "fragile")
            {
                carsToPrint = cars
                        .Where(x => x.Cargo.Type == "fragile"
                        && x.Tires.Any(t => t.Presure < 1))
                        .ToList();


                //foreach(var car in cars)
                //{
                //    if (car.Cargo.Type =="fragile")
                //    {
                //        foreach (var tire in car.Tires)
                //        {
                //            if (tire.Presure<1)
                //            {
                //                Console.WriteLine(car.Model);
                //                break;
                //            }
                //        }
                //    }
                //}

            }
            else
            {
                carsToPrint = cars
                    .Where(x => x.Cargo.Type == "flammable"
                    && x.Engine.Power > 250)
                    .ToList();

            }
            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
