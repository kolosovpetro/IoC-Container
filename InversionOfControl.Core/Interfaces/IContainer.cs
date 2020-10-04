namespace InversionOfControl.Interfaces
{
    public interface IContainer
    {
        /// <summary>
        /// Adds a new service with transient lifetime to the list of dependencies.
        /// </summary>
        void RegisterTransient<TContract, TImplementation>();

        /// <summary>
        /// Adds a new service with singleton lifetime to the list of dependencies.
        /// </summary>
        void RegisterSingleton<TContract, TImplementation>();

        /// <summary>
        /// Registers type given concrete instance. Doesn't support objects with overloaded constructor.
        /// </summary>
        void RegisterSingletonInstance<TContract, TImplementation>(TImplementation instance);

        /// <summary>
        /// Returns concrete implementation of Contract. Doesn't support objects with overloaded constructor.
        /// </summary>
        TContract GetInstance<TContract>();
    }
}