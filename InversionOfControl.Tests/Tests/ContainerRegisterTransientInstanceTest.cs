using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Enums;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class ContainerRegisterTransientInstanceTest
    {
        [Test]
        public void Container_Register_Transient_Instance_Simple_Test()
        {
            IContainer container = new Container();
            container.RegisterTransient<ILogger, Logger>(new Logger());
            var service = container.GetService<ILogger>();
            service.LifeTime.Should().Be(LifeTime.Transient);
            service.Contract.Should().Be(typeof(ILogger));
            service.Implementation.Should().Be(typeof(Logger));

            var logger = service.GetInstance<ILogger>();
            logger.Log("test").Should().Be("This logger inserted new entry: test");
        }

        [Test]
        public void Container_Register_Transient_Instance_Test()
        {
            IContainer container = new Container();
            container.RegisterTransient<ILoggerService, LoggerService>(new LoggerService(new Logger()));
            var service = container.GetService<ILoggerService>();
            service.LifeTime.Should().Be(LifeTime.Transient);

            var loggerService = service.GetInstance<ILoggerService>();
            loggerService.LogMessage("test").Should().Be("This logger inserted new entry: test");
        }
    }
}