using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class ExecutiveAccount : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{person.FirstName}.{person.LastName}@acmeCorp.com";

            output.IsManager = true;
            output.IsExecutive = true;

            return output;
        }
    }
}
