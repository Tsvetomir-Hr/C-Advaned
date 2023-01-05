using DependencyInjectionFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionFramework
{
    public class Engine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        public Engine(IReader reader, ILogger logger)
        {
            this.reader = reader;
            this.logger = logger;
        }

        public void Start()
        {
            while (true)
            {
                reader.Read();
                logger.Log("running");
            }
        }
    }
}
