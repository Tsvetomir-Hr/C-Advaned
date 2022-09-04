using System;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List list = new List();
            list.Add(5);
            list.Add(10);
            list.Add(125);
            list.Add(12);


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

          
            
        }
    }
}
