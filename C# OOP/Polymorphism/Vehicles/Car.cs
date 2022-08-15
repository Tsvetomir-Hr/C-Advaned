using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm) : base(tankCapacity, fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 0.9;
    }
}
