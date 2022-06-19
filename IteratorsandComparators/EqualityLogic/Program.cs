using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet <Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split();
                string name  = personInfo[0];
                int age = int.Parse(personInfo[1]);

                sortedSet.Add(new Person(name, age));
                hashSet.Add(new Person(name, age));
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);

        }
    }
}
