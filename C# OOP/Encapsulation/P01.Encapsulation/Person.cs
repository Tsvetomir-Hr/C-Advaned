using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExersise
{
    public class Person
    {


        private List<Product> products;
        private string name;
        private decimal money;

        public Person(string name,decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products => products;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public bool AddProduct(Product product)
        {
            if (Money-product.Cost<0)
            {
                return false;
            }

            products.Add(product);
            Money -= product.Cost;
            return true;
        }
    }
}
