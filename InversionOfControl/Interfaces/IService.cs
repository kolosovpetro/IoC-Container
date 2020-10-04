using System;
using InversionOfControl.Enums;

namespace InversionOfControl.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Type of contract of an entity
        /// </summary>
        Type Contract { get; }
        
        /// <summary>
        /// Type of concrete implementation of Contract
        /// </summary>
        Type Implementation { get; }
        
        /// <summary>
        /// Lifetime of the service
        /// </summary>
        LifeTime LifeTime { get; }
        
        /// <summary>
        /// Concrete implementation of Contract
        /// </summary>
        object Instance { get; set; }
    }
}