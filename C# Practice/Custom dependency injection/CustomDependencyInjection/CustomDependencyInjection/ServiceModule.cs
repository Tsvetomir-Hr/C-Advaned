using CustomDependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependencyInjection
{
    public abstract class ServiceModule : IServiceModule
    {
        Dictionary<Type, Type> mappings;
        Dictionary<Type, object> instances;
        public ServiceModule()
        {
            mappings = new Dictionary<Type, Type>();
            instances = new Dictionary<Type, object>();
        }

        public void AddSingleton<TInterface, TImplementation>()
        {
            mappings[typeof(TInterface)] = typeof(TImplementation);
        }

        public abstract void Configure();
       
    }
}
