using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;

        }
        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumptionPerKm { get;protected set; }
        public double TankCapacity { get; }
        public bool IsEmpty { get; set; }

        public bool CanRefuel(double amount)
            => FuelQuantity + amount <= TankCapacity;

        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                FuelQuantity -= km * FuelConsumptionPerKm;
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (CanRefuel(amount))
            {
                FuelQuantity += amount;

            }
        }
        public bool CanDrive(double km)
            => FuelQuantity - (km * FuelConsumptionPerKm) >= 0;
    }
}
