using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests;

[TestFixture]
public class ContainerRegisterTransientTest
{
    [Test]
    public void Container_Register_Transient_Test()
    {
        IBuilder builder = new Builder();
        builder.AddTransient<ILogger, Logger>();
        builder.AddTransient<ILoggerService, LoggerService>();
        var container = builder.Build();
        var loggerService = container.GetInstance<ILoggerService>();
        loggerService.LogMessage("test").Should().Be("This logger inserted new entry: test");
    }
}