using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependencyInjection.Contracts
{
    interface IServiceModule
    {
        void AddSingleton<TInterface, TImplementation>();
        void Configure();
    }
}
