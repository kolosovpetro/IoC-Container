using InversionOfControl.Entities.Interfaces;

namespace InversionOfControl.Entities.Implementations
{
    public class Logger : ILogger
    {
        public string Log(string data) => $"This logger inserted new entry: {data}";
    }
}