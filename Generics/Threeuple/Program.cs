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

            MyTuple<string, string, string> personInfo = new MyTuple<string, string, string>(
                $"{personInput[0]} {personInput[1]}",
                personInput[2],personInput[3]);

            bool drunk = beerInput[2] == "drunk" ? true : false;
            int liters = int.Parse(beerInput[1]);
            MyTuple<string, int,bool> beerInfo = new MyTuple<string, int,bool>(beerInput[0], liters,drunk);


            string name = numbersInput[0];
            double dbl = double.Parse(numbersInput[1]);
            string bankName = numbersInput[2];

            MyTuple<string, double,string> numbersInfo = new MyTuple<string, double, string>(name, dbl,bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(numbersInfo);
        }
    }
}
