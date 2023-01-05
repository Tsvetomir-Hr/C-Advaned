using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        IBusinessLogic businessLogic;
        public Application(IBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        public void Run()
        {
            this.businessLogic.ProcessData();
        }
    }
}
