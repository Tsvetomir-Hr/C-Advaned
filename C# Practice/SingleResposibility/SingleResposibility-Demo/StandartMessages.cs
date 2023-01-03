using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResposibility_Demo
{
    public class StandartMessages
    {

        public static void WelcomeMessage() 
        {
            Console.WriteLine("Welcome to my application!");
        }

        public static void EndApplication()
        {
            Console.Write("Press enter to close...");
            Console.ReadLine();
        }

        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"You did give us a valid {fieldName}!");

        }
    }
}
