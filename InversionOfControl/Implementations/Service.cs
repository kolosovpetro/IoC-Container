using System;
using InversionOfControl.Enums;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Service : IService
    {
        public Type Contract { get; set; }
        public Type Implementation { get; set; }
        public LifeTime LifeTime { get; set; }
        public object Instance { get; set; }

        public Service(Type contract, Type implementation, object instance, LifeTime lifeTime)
        {
            Contract = contract;
            Implementation = implementation;
            LifeTime = lifeTime;
            Instance = instance;
        }

        public TContract GetInstance<TContract>()
        {
            return (TContract) Instance;
        }
    }
}