using System;
using System.Collections.Generic;
using InversionOfControl.Enums;
using InversionOfControl.Exceptions;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Container : IContainer
    {
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public void RegisterTransient<TContract, TImplementation>()
        {
            ThrowExceptionIfAlreadyRegistered(typeof(TContract));
            ThrowExceptionIfNotSubtype(typeof(TContract), typeof(TImplementation));

            _services[typeof(TContract)]
                = new Service(typeof(TContract), typeof(TImplementation), LifeTime.Transient);
        }

        public void RegisterSingleton<TContract, TImplementation>()
        {
            ThrowExceptionIfAlreadyRegistered(typeof(TContract));
            ThrowExceptionIfNotSubtype(typeof(TContract), typeof(TImplementation));

            _services[typeof(TContract)]
                = new Service(typeof(TContract), typeof(TImplementation), LifeTime.Singleton);
        }

        public void RegisterSingletonInstance<TContract, TImplementation>(TImplementation instance)
        {
            ThrowExceptionIfAlreadyRegistered(typeof(TContract));
            ThrowExceptionIfNotSubtype(typeof(TContract), typeof(TImplementation));

            _services[typeof(TContract)] =
                new Service(typeof(TContract), typeof(TImplementation), instance, LifeTime.Singleton);
        }

        private IService GetService<TContract>()
        {
            ThrowExceptionIfNotRegistered(typeof(TContract));

            var obj = _services[typeof(TContract)];

            switch (obj.LifeTime)
            {
                case LifeTime.Transient:
                {
                    var contract = obj.Contract;
                    var implementation = obj.Implementation;
                    var instance = Resolve(typeof(TContract));
                    var lifeTime = obj.LifeTime;
                    return new Service(contract, implementation, instance, lifeTime);
                }
                case LifeTime.Singleton when !obj.InstanceInitialized:
                    obj.Instance = Resolve(typeof(TContract));
                    return obj;
                default:
                    return obj;
            }
        }

        public TContract GetInstance<TContract>()
        {
            var service = GetService<TContract>();
            return (TContract) service.Instance;
        }

        private object Resolve(Type contract)
        {
            var implementation = _services[contract].Implementation;

            var constructor = implementation.GetConstructors()[0];
            var constructorParams = constructor.GetParameters();

            if (constructorParams.Length == 0)
                return Activator.CreateInstance(implementation);

            var parameters = new List<object>();

            foreach (var param in constructorParams)
                parameters.Add(Resolve(param.ParameterType));

            return constructor.Invoke(parameters.ToArray());
        }

        private void ThrowExceptionIfAlreadyRegistered(Type contract)
        {
            if (IsRegistered(contract))
                throw new TypeAlreadyRegisteredException($"Type {contract} is already registered");
        }

        private void ThrowExceptionIfNotRegistered(Type contract)
        {
            if (!IsRegistered(contract))
                throw new TypeNotRegisteredException($"Type {contract} is not registered");
        }

        private static void ThrowExceptionIfNotSubtype(Type baseType, Type subType)
        {
            if (!IsSubtype(baseType, subType))
                throw new InvalidTypeException($"Type {subType} is not {baseType}");
        }

        private bool IsRegistered(Type contract)
        {
            return _services.ContainsKey(contract);
        }

        private static bool IsSubtype(Type baseType, Type subType)
        {
            return baseType.IsAssignableFrom(subType);
        }
    }
}