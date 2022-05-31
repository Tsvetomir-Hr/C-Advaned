using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }


       

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == " " || animal.Species == null)
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count==Capacity)
            {
                return "The zoo is full.";
            }
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int animalsCount = Animals.Count;

            Animals.RemoveAll(animal => animal.Species == species);
            return animalsCount-Animals.Count;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = new List<Animal>();

            foreach (var animal in Animals)
            {
                if (animal.Diet == diet)
                {
                    animalsByDiet.Add(animal);
                }
            }
            return animalsByDiet;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal = Animals.FirstOrDefault(x => x.Weight == weight);

            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int counter = 0;
            foreach (var animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    counter++;
                }
            }
            return $"There are {counter} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
