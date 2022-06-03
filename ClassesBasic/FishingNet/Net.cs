using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public readonly List<Fish> Fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => Fish.Count;

        public object StringBuiler { get; private set; }

        public string AddFish(Fish fish)
        {
            if (Count < Capacity)
            {
                if (fish.FishType != null &&
                    fish.FishType != " " &&
                    fish.Length > 0 &&
                    fish.Weight > 0)
                {
                    Fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";

                }
                return "Invalid fish.";
            }
            return "Fishing net is full.";
        }
        public bool ReleaseFish(double weight)
        {
            Fish fish = Fish.FirstOrDefault(x => x.Weight == weight);
            if (fish == null)
            {
                return false;
            }
            Fish.Remove(fish);
            return true;
        }
        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(x => x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
