using DependencyInjectionFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionFramework
{
    public class SpecialLogger : ILogger
    {
        public void Log(string log)
        {
            Console.WriteLine($"You are special! {log}");
        }
    }
}
