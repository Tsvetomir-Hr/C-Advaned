using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        HashSet<Car> Participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            this.Participants = new HashSet<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            //bool isFound = false;
            //foreach (Car car1 in Participants)
            //{
            //    if (car1.LicensePlate == car.LicensePlate)
            //    {
            //        isFound = true;
            //        break;
            //    }
            //}
            //if (isFound==false)
            //{
                if (Participants.Count < Capacity)
                 {
                    if (car.HorsePower <= MaxHorsePower)
                    {

                        Participants.Add(car);
                    }
                }
            //}

        }
        public bool Remove(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (car == null)
            {
                return false;
            }
            Participants.Remove(car);
            return true;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            return car;
        }
        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (Car car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
