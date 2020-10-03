using System;
using InversionOfControl.Enums;

namespace InversionOfControl.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Type of contract of an entity
        /// </summary>
        Type Contract { get; set; }
        
        /// <summary>
        /// Type of concrete implementation of Contract
        /// </summary>
        Type Implementation { get; set; }
        
        /// <summary>
        /// Lifetime of the service
        /// </summary>
        LifeTime LifeTime { get; set; }
        
        /// <summary>
        /// Concrete instance of an implementation
        /// </summary>
        object Instance { get; set; }
    }
}