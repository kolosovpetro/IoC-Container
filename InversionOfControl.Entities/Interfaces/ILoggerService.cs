namespace InversionOfControl.Entities.Interfaces;

public interface ILoggerService
{
    void Log(string text);
    string LogMessage(string text);
}