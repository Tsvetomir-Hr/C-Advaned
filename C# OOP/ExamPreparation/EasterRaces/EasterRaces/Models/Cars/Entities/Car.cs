using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value,4));
                }
                model = value; 
            }
        }


        public virtual int HorsePower { get; protected set;}

        public double CubicCentimeters => throw new NotImplementedException();

        public double CalculateRacePoints(int laps)
        {
            throw new NotImplementedException();
        }
    }
}
