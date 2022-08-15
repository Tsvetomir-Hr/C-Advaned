using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumptionPerKm { get; }

        public double TankCapacity { get; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km);

        public bool CanRefuel(double amount);

        public void Drive(double km);

        public void Refuel(double amount);
    }
}
