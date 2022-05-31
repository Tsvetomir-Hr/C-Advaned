using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    internal class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make,string model,int year):this()
        {
            Make = make;
            Model = model;
            Year = year;

        }
        public Car(string make, string model, int year,int fuelQuantity , int fuelConsumption) : this(make,model,year)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;

        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public string WhoAmI()
        {
            return $"Make: {this.Make} Model: { this.Model} Year: { this.Year} Fuel: { this.FuelQuantity:F2}";
        }
    }
}
