using System;
using InversionOfControl.Entities.Interfaces;

namespace InversionOfControl.Entities.Implementations
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string text)
        {
            Console.WriteLine(_logger.Log(text));
        }

        public string LogMessage(string text)
        {
            return _logger.Log(text);
        }
    }
}