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
    }
}