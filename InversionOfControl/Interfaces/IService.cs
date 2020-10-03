using InversionOfControl.Enums;

namespace InversionOfControl.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Returns an instance
        /// </summary>
        TContract Resolve<TContract>();

        /// <summary>
        /// Returns lifetime of the instance
        /// </summary>
        LifeTime LifeTime { get; }
    }
}