using DependencyInjectionFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionFramework
{
    public class ConsoleReader : IReader
    {
        private readonly ILogger logger;
        public ConsoleReader(ILogger logger)
        {
            this.logger = logger;
        }
        public string Read()
        {
            logger.Log("Reading");
           return Console.ReadLine();
        }
    }
}
