using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] personInput = Console.ReadLine()
                .Split(' ');

            string[] beerInput = Console.ReadLine()
                .Split(' ');

            string[] numbersInput = Console.ReadLine()
                .Split(' ');

            MyTuple<string, string> personInfo = new MyTuple<string, string>(
                $"{personInput[0]} {personInput[1]}",
                personInput[2]);




            int liters = int.Parse(beerInput[1]);
            MyTuple<string, int> beerInfo = new MyTuple<string, int>(beerInput[0], liters);


            int integer = int.Parse(numbersInput[0]);
            double dbl = double.Parse(numbersInput[1]);

            MyTuple<int, double> numbersInfo = new MyTuple<int, double>(integer, dbl);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(numbersInfo);
        }
    }
}
