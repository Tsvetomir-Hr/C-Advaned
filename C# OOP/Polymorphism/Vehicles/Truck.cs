using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm) : base(tankCapacity, fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.6;

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95); // 95 % from the fuel
        }
    }
}
