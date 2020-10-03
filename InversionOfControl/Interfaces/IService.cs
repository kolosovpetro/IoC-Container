using InversionOfControl.Enums;

namespace InversionOfControl.Interfaces
{
    public interface IService<out TContract>
    {
        /// <summary>
        /// Returns an instance
        /// </summary>
        TContract GetInstance { get; }
        
        /// <summary>
        /// Returns lifetime of the instance
        /// </summary>
        LifeTime LifeTime { get; }
    }
}