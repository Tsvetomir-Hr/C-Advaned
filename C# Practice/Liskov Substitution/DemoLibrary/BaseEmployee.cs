using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BaseEmployee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAmout = 12.50M;
            this.Salary = baseAmout + (rank * 2);
        }
    }
}
