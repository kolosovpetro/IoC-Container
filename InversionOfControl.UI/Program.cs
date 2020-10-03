using System;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Implementations;

namespace InversionOfControl.UI
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var container = new Container();
            container.RegisterSingleton<ILogger, Logger>();
            Console.WriteLine(container.Services.Count);
            var service = container.GetService<ILogger>();
            Console.WriteLine(service.LifeTime);
            var logger = (ILogger) service.Instance;
            Console.WriteLine(logger.Log("test"));
        }
    }
}