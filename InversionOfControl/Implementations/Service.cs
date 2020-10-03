using System;
using InversionOfControl.Enums;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Service : IService
    {
        public Type Contract { get; }
        public Type Implementation { get; }
        public LifeTime LifeTime { get; }
        private object Instance { get; set; }

        public Service(Type contract, Type implementation, LifeTime lifeTime)
        {
            Contract = contract;
            Implementation = implementation;
            LifeTime = lifeTime;
        }

        public Service(Type contract, Type implementation, object instance, LifeTime lifeTime)
        {
            Contract = contract;
            Implementation = implementation;
            LifeTime = lifeTime;
            Instance = instance;
        }

        public void SetInstance(object instance)
        {
            Instance = instance;
        }

        public TContract GetInstance<TContract>()
        {
            return (TContract) Instance;
        }
    }
}