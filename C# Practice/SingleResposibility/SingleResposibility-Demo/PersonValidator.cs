using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResposibility_Demo
{
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                StandartMessages.DisplayValidationError("first name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                StandartMessages.DisplayValidationError("last name");
                return false;
            }
            return true;
        }
    }
}
