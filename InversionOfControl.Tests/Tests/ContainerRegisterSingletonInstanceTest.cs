using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class ContainerRegisterSingletonInstanceTest
    {
        [Test]
        public void Container_Register_Singleton_Instance_Test()
        {
            IBuilder builder = new Builder();
            builder.AddSingletonInstance<ILoggerService, LoggerService>(new LoggerService(new Logger()));
            var container = builder.Build();
            var loggerService = container.GetInstance<ILoggerService>();
            loggerService.LogMessage("test").Should().Be("This logger inserted new entry: test");
        }
    }
}