using System;
using System.Collections.Generic;
using System.Linq;
using InversionOfControl.Enums;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Container : IContainer
    {
        public readonly List<IService> Services = new List<IService>();

        public void RegisterTransient<TContract, TImplementation>()
        {
            Services.Add(new Service
            {
                Contract = typeof(TContract),
                Implementation = typeof(TImplementation),
                LifeTime = LifeTime.Transient
            });
        }

        public void RegisterSingleton<TContract, TImplementation>()
        {
            Services.Add(new Service
            {
                Contract = typeof(TContract),
                Implementation = typeof(TImplementation),
                LifeTime = LifeTime.Singleton
            });
        }

        public IService GetService<TContract>()
        {
            return new Service
            {
                Contract = typeof(TContract),
                Implementation = Services.First(x => x.Contract == typeof(TContract))
                    .Implementation,
                Instance = Resolve(typeof(TContract)),
                LifeTime = Services.First(x => x.Contract == typeof(TContract))
                    .LifeTime
            };
        }

        public object Resolve(Type contract)
        {
            var implementation = Services
                .First(x => x.Contract == contract)
                .Implementation;

            var constructor = implementation.GetConstructors()[0];
            var constructorParams = constructor.GetParameters();

            if (constructorParams.Length == 0)
                return Activator.CreateInstance(implementation);

            var parameters = new List<object>();

            foreach (var param in constructorParams)
                parameters.Add(Resolve(param.ParameterType));

            return constructor.Invoke(parameters.ToArray());
        }
    }
}