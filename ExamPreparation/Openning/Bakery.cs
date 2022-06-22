using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Count<Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            if (employee == null)
            {
                return false;
            }

            data.Remove(employee);
            return true;
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public string GetEmployee(int age, string country ) //   GetEmployee(25,Bulgaria);
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            sb.AppendLine("AllEmployees:");
            foreach (var emp in data)
            {
                if (emp.Age==age && emp.Country==country)
                {
                    counter++;
                    sb.AppendLine(emp.ToString());
                }
            }
            if (counter==0)
            {
                sb.AppendLine("0");
            }
           return sb.ToString().TrimEnd();
          
         
            
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
