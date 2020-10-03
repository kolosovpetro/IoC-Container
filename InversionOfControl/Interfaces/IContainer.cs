namespace InversionOfControl.Interfaces
{
    public interface IContainer
    {
        /// <summary>
        /// Adds a new service with transient lifetime to the list of dependencies
        /// </summary>
        void RegisterTransient<TContract, TImplementation>();
        
        /// <summary>
        /// Registers type given concrete instance. 
        /// </summary>
        void RegisterTransient<TContract, TImplementation>(TImplementation instance);

        /// <summary>
        /// Adds a new service with singleton lifetime to the list of dependencies
        /// </summary>
        void RegisterSingleton<TContract, TImplementation>();

        /// <summary>
        /// Registers type given concrete instance. 
        /// </summary>
        void RegisterSingleton<TContract, TImplementation>(TImplementation instance);

        /// <summary>
        /// Returns a service from dependencies list
        /// </summary>
        IService GetService<TContract>();
    }
}