using DependencyInjectionFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionFramework
{
    public class Logger : ILogger
    {
        private DateTime dateToday;
        public Logger(DateTime dateToday)
        {
            this.dateToday = dateToday;
        }
        public void Log(string log)
        {
            Console.WriteLine($"{dateToday.ToString("G")} {log}");
        }
    }
}
