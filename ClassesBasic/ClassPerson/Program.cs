using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Person person = new Person("Peter", 20);


            Person newPerson = new Person();

            newPerson.Name = "George";
            newPerson.Age = 25;

        }
    }
}
