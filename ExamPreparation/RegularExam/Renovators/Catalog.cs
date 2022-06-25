using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name==null || renovator.Name==string.Empty ||
                renovator.Type==null || renovator.Type==string.Empty)
            {
                return "Invalid renovator's information.";
            }
            if (Count>=NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            if (renovator==null)
            {
                return false;
            }
            renovators.Remove(renovator);
            return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;
            List<Renovator> renovatorsToRemove = new List<Renovator>();
            foreach (var renovator in renovators)
            {

                if (renovator.Type==type)
                {
                    renovatorsToRemove.Add(renovator);
                    count++;
                }
            }
            foreach (var renovator in renovatorsToRemove)
            {
                renovators.Remove(renovator);
            }
            return count;
        }
        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            if (renovator!=null)
            {
                renovator.Hired = true;
            }
            return renovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsToReturn = new List<Renovator>();
            foreach (var renovator in renovators)
            {
                if (renovator.Days>=days)
                {
                    renovatorsToReturn.Add(renovator);
                }
            }
            return renovatorsToReturn;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in renovators.Where(x=>x.Hired==false))
            {
                sb.AppendLine(renovator.ToString());
            }

             return sb.ToString().TrimEnd();
        }


    }
}
