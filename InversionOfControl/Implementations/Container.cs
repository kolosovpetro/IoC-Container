using System.Collections.Generic;
using InversionOfControl.Interfaces;

namespace InversionOfControl.Implementations
{
    public class Container: IContainer
    {
        private readonly List<IService> _services = new List<IService>();
        
        public void RegisterTransient<TContract, TImplementation>()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterSingleton<TContract, TImplementation>()
        {
            throw new System.NotImplementedException();
        }

        public IService GetService<TContract>()
        {
            throw new System.NotImplementedException();
        }
    }
}