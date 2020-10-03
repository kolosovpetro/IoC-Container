using System;
using System.Collections.Generic;
using System.Linq;
using InversionOfControl.Enums;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Container : IContainer
    {
        private readonly List<IService> _services = new List<IService>();
        private readonly Dictionary<Type, IService> _instances = new Dictionary<Type, IService>();

        public void RegisterTransient<TContract, TImplementation>()
        {
            _services.Add(new Service
            {
                Contract = typeof(TContract),
                Implementation = typeof(TImplementation),
                LifeTime = LifeTime.Transient
            });
        }

        public void RegisterTransient<TContract, TImplementation>(TImplementation instance)
        {
            _instances[typeof(TContract)] = new Service
            {
                Contract = typeof(TContract),
                Implementation = typeof(TImplementation),
                Instance = instance,
                LifeTime = LifeTime.Transient
            };
        }

        public void RegisterSingleton<TContract, TImplementation>()
        {
            _services.Add(new Service
            {
                Contract = typeof(TContract),
                Implementation = typeof(TImplementation),
                LifeTime = LifeTime.Singleton
            });
        }

        public void RegisterSingleton<TContract, TImplementation>(TImplementation instance)
        {
            _instances[typeof(TContract)] = new Service
            {
                Contract = typeof(TContract),
                Implementation = typeof(TImplementation),
                Instance = instance,
                LifeTime = LifeTime.Singleton
            };
        }

        public IService GetService<TContract>()
        {
            if (_instances.ContainsKey(typeof(TContract)))
                return _instances[typeof(TContract)];

            return new Service
            {
                Contract = typeof(TContract),
                Implementation = _services.First(x => x.Contract == typeof(TContract))
                    .Implementation,
                Instance = Resolve(typeof(TContract)),
                LifeTime = _services.First(x => x.Contract == typeof(TContract))
                    .LifeTime
            };
        }

        private object Resolve(Type contract)
        {
            var implementation = _services
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