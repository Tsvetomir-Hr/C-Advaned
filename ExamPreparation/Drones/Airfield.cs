using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (Count < Capacity)
            {
                if (drone.Name != null &&
                    drone.Brand != null &&
                    drone.Name != string.Empty &&
                    drone.Brand != string.Empty &&
                    drone.Range >= 5 &&
                    drone.Range <= 15)
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                return "Invalid drone.";

            }
            return "Airfield is full.";
        }
        public bool RemoveDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone == null)
            {
                return false;
            }
            Drones.Remove(drone);
            return true;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int droneCounter = 0;
            List<Drone> dronesToRemove = new List<Drone>();
            
            foreach (Drone drone in Drones)
            {
                if (drone.Brand == brand)
                {
                    dronesToRemove.Add(drone);
                    
                }
            }
            foreach (var drone in dronesToRemove)
            {
                if (drone.Brand==brand)
                {
                    Drones.Remove(drone);
                    droneCounter++;
                }
            }
            return droneCounter;
        }
        public Drone FlyDrone(string name)
        {
            Drone droneToFly = Drones.FirstOrDefault(x => x.Name == name);
            if (droneToFly == null)
            {
                return null;
            }
            droneToFly.Available = false;
            return droneToFly;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = new List<Drone>();

            foreach (Drone drone in Drones)
            {
                if (drone.Available == true &&
                    drone.Range == range
                    )
                {
                    drone.Available = false;
                    flownDrones.Add(drone);
                }
            }
            return flownDrones;

        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
