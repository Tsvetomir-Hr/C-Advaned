using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope= container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                //in this scope which is the scope of the container the scope.Resolve give us an IApplication.And this is out application instance.
                app.Run();
            }

                Console.ReadLine();
        }
    }
}
