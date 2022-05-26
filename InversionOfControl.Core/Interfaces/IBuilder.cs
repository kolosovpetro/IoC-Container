namespace InversionOfControl.Interfaces;

public interface IBuilder
{
    /// <summary>
    /// Adds a new transient item by implementation type to container.
    /// </summary>
    void AddTransient<TContract, TImplementation>();

    /// <summary>
    /// Adds a new singleton item by implementation type to container.
    /// </summary>
    void AddSingleton<TContract, TImplementation>();

    /// <summary>
    /// Adds a new singleton item by instance type to container.
    /// </summary>
    void AddSingletonInstance<TContract, TImplementation>(TImplementation instance);

    /// <summary>
    /// Returns a concrete container.
    /// </summary>
    IContainer Build();
}