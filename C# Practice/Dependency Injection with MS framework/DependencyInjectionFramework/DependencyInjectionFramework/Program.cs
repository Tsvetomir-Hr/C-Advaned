using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = new DIConfigurator().Configure();
            Engine engine = serviceProvider.GetRequiredService<Engine>();

            engine.Start();
        }
    }
}
