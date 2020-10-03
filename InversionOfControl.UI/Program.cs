using System;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using Container = InversionOfControl.Implementations.Container;
using IContainer = InversionOfControl.Interfaces.IContainer;

namespace InversionOfControl.UI
{
    public static class Program
    {
        private static void Main()
        {
            IContainer container = new Container();
            container.RegisterSingleton<ILogger, Logger>();
            var service = container.GetService<ILogger>();
            Console.WriteLine(service.LifeTime);
            var logger = (ILogger) service.Instance;
            Console.WriteLine(logger.Log("test"));
        }
    }
}