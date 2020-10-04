using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Builder : IBuilder
    {
        private readonly IContainer _container = new Container();
        
        public void AddTransient<TContract, TImplementation>()
        {
            _container.RegisterTransient<TContract, TImplementation>();
        }

        public void AddSingleton<TContract, TImplementation>()
        {
            _container.RegisterSingleton<TContract, TImplementation>();
        }

        public void AddSingletonInstance<TContract, TImplementation>(TImplementation instance)
        {
            _container.RegisterSingletonInstance<TContract, TImplementation>(instance);
        }

        public IContainer Build()
        {
            return _container;
        }
    }
}