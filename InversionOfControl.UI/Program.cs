using System;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;

namespace InversionOfControl.UI
{
    public static class Program
    {
        private static void Main()
        {
            IBuilder builder = new Builder();
            builder.AddSingleton<ILogger, Logger>();
            builder.AddSingleton<ILoggerService, LoggerService>();
            builder.AddSingleton<IRandomNumber, RandomNumber>();
            var container = builder.Build();
            var loggerService = container.GetInstance<ILoggerService>();
            loggerService.Log("test");
            var random1 = container.GetInstance<IRandomNumber>();
            var random2 = container.GetInstance<IRandomNumber>();
            Console.WriteLine($"Random number from singleton {nameof(random1)}: {random1.GetRandomNumber()}");
            Console.WriteLine($"Random number from singleton {nameof(random2)}: {random2.GetRandomNumber()}");
        }
    }
}