using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResposibility_Demo
{
    public class AccountGenerator
    {
        public static void CreateAccount(Person user)
        {
            Console.WriteLine($"Your username is {user.FirstName.Substring(0, 1)}{user.LastName}");
        }
    }
}
