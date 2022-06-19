using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToList();

            ListyIterator<string> listyIterator =
                new ListyIterator<string>(elements);
            string commands = Console.ReadLine();
            try
            {
                while (commands != "END")
                {
                    if (commands == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (commands == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (commands == "Print")
                    {
                        listyIterator.Print();
                    }
                    commands = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
