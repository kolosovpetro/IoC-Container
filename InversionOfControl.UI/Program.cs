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
            var container = builder.Build();
            var loggerService = container.GetInstance<ILoggerService>();
            loggerService.Log("test");
        }
    }
}