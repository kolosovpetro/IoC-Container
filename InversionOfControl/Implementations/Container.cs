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
            _services.Add(new Service(typeof(TContract), typeof(TImplementation), null, LifeTime.Transient));
        }

        public void RegisterTransient<TContract, TImplementation>(TImplementation instance)
        {
            _instances[typeof(TContract)] =
                new Service(typeof(TContract), typeof(TImplementation), instance, LifeTime.Transient);
        }

        public void RegisterSingleton<TContract, TImplementation>()
        {
            _services.Add(new Service(typeof(TContract), typeof(TImplementation), null, LifeTime.Singleton));
        }

        public void RegisterSingleton<TContract, TImplementation>(TImplementation instance)
        {
            _instances[typeof(TContract)] =
                new Service(typeof(TContract), typeof(TImplementation), instance, LifeTime.Singleton);
        }

        public IService GetService<TContract>()
        {
            if (_instances.ContainsKey(typeof(TContract)))
                return _instances[typeof(TContract)];

            var obj = _services.First(x => x.Contract == typeof(TContract));
            var contract = typeof(TContract);
            var implementation = obj.Implementation;
            var instance = Resolve(typeof(TContract));
            var lifetime = obj.LifeTime;

            return new Service(contract, implementation, instance, lifetime);
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