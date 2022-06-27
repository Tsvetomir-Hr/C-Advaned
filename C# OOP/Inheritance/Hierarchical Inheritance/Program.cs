using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Dog dog = new Dog();
            Console.WriteLine("Dog is:");
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            Console.WriteLine("Cat is:");
            cat.Eat();
            cat.Meow();


        }
    }
}
