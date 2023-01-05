using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();
            // register the class businessLogic and respond when someone need IBusinessLogic.

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces()
                .FirstOrDefault(i => i.Name == "I" + t.Name));
            //here we are looking in all interfaces in this assembly in given namaspace for the interface for the the concrete class.
            //Also can reuse this code for another project just need to change the assembly and the name of the folder that we want to map.

            return builder.Build(); //builds the container
        }
    }
}
