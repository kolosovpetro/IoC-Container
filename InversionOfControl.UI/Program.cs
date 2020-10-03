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
            container.RegisterSingleton<ILoggerService, LoggerService>();
            var service = container.GetService<ILoggerService>();
            
            
            var loggerService = service.GetInstance<ILoggerService>();
            loggerService.Log("test");
        }
    }
}