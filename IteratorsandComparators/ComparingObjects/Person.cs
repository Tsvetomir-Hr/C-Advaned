using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string  Town { get; set; }

        public int CompareTo( Person other)
        {
            int names = Name.CompareTo(other.Name);
            if (names!=0)
            {
                return names;
            }
            int age = Age.CompareTo(other.Age);
            if (age!=0)
            {
                return age;
            }
            int town = Town.CompareTo(other.Town);
            if (town!=0)
            {
                return town;
            }
            //Name !=
            //Age 
            //Town
            return 0;
        }
    }
}
