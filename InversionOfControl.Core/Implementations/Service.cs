using System;
using InversionOfControl.Enums;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations;

public class Service : IService
{
    public Type Contract { get; }
    public Type Implementation { get; }
    public LifeTime LifeTime { get; }
    public object Instance { get; set; }

    public bool InstanceInitialized => Instance != null;

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
}